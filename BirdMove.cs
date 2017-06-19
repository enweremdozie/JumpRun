using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

	public float moveDuration = 0f;
	public float moveStart = 0f;
	public Vector3 initialVel = new Vector3();

	private GameObject masterAudio;

	// Use this for initialization
	void Start () {
		moveStart = Time.time;
		this.rigidbody.velocity = initialVel;
		masterAudio = GameObject.FindWithTag ("AudioObject");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (moveStart + moveDuration <= Time.time) {

			Vector3 currVel = this.rigidbody.velocity;
			currVel.y = 0;
			this.rigidbody.velocity = currVel;

		}

	}

	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "Player") {
			masterAudio.SendMessage ("OtBirdDied", SendMessageOptions.DontRequireReceiver);
			GameObject.Destroy(gameObject);
			
		}
		
	}

}
