using UnityEngine;
using System.Collections;

public class JumperEnemy : MonoBehaviour {

	public float lastJump = 0f;
	public float jumpInterval = 3f;
	public float jumpDelay = 0f;

	public float jumpPower = 6.0f;

	// This is for tracking starting location.
	private Vector3 originPosition;

	Animator _copAnimator;
	private GameObject masterAudio;

	// Use this for initialization
	void Start () 
	{
		masterAudio = GameObject.FindWithTag ("AudioObject");
		lastJump = Time.time + jumpDelay;

		gameObject.layer = 9; // Should be a layer called 'enemy', for ignoring enemy v enemy collision.

		_copAnimator = gameObject.GetComponentInChildren<Animator>();
		originPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () 
	{
	

		if(lastJump + jumpInterval <=  Time.time){

			Vector3 currVel = this.rigidbody.velocity;
			currVel.y = jumpPower;
			this.rigidbody.velocity = currVel;

			lastJump = Time.time;
			_copAnimator.SetTrigger ("Jumped");
			masterAudio.SendMessage ("CJump", SendMessageOptions.DontRequireReceiver);

		}

		if (Mathf.Abs(transform.position.y - originPosition.y) < 0.1f)
		{
			_copAnimator.SetBool ("NonVertical", true);
		}
		else
		{
			_copAnimator.SetBool ("NonVertical", false);
		}


	}

	void OnCollisionEnter(Collision collision) 
	{

		if (collision.gameObject.tag == "Player") 
		{
			masterAudio.SendMessage ("CDied", SendMessageOptions.DontRequireReceiver);
			GameObject.Destroy(gameObject);

		}

	}

}
