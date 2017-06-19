using UnityEngine;
using System.Collections;

public class EnemyRunner : MonoBehaviour {

	/// <summary>
	/// Animation variables
	/// </summary>
	Animator _copAnim;
	private bool verticalMotion = false;

	
	public float force = 250.0f;
	public float force2 = 350.0f;
	public float force3 = 500.0f;
	
	public float enemySpeed = -3f;
	
	// Use this for initialization
	void Start () 
	{
		_copAnim = gameObject.GetComponentInChildren <Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 currVel = this.rigidbody.velocity;
		currVel.z = enemySpeed;
		this.rigidbody.velocity = currVel;
		
		UpdateAnimation();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Jump"))
		{
			rigidbody.AddForce (0.0f, force, 0.0f);
		}
		if (other.CompareTag ("Jump2"))
		{
			rigidbody.AddForce (0.0f, force2, 0.0f);
		}
		if (other.CompareTag ("Jump3"))
		{
			rigidbody.AddForce (0.0f, force3, 0.0f);
		}
	}
	
	
	void OnCollisionEnter(Collision collision) 
	{
		
		if (collision.gameObject.tag == "Player") 
		{
			GameObject.Destroy(gameObject);
		}
		
	}
	
	
	void UpdateAnimation()
	{
		if (rigidbody.velocity.y > 0.1f)
		{
			verticalMotion = true;
		}
		else if (rigidbody.velocity.y < -1.0f)
		{
			verticalMotion = true;
			_copAnim.SetTrigger ("Falling");
		}
		else
		{
			verticalMotion = false;
		}
		_copAnim.SetBool ("VerticalMotion", verticalMotion);

	}
}
