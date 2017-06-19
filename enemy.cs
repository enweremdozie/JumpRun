using UnityEngine;
using System.Collections;



public class enemy : MonoBehaviour {
	
	public float enemySpeed = -7f;

	public float force;
	public float force2;
	public float force3;
	
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currVel = this.rigidbody.velocity;
		currVel.z = enemySpeed;
		this.rigidbody.velocity = currVel;
	}


	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "Player") {
			GameObject.Destroy(gameObject);
			
		}
		
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Jump")) {
			rigidbody.AddForce (0,force,0);
		}
		
		if (other.CompareTag("Jump2")) {
			rigidbody.AddForce (0,force2,0);
		}
		
		if (other.CompareTag("Jump3")) {
			rigidbody.AddForce (0,force3,0);
		}
	}

}
