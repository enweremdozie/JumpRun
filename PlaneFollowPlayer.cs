using UnityEngine;
using System.Collections;

public class PlaneFollowPlayer : MonoBehaviour {

	public GameObject playerPtr;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

		if(playerPtr != null){

			Vector3 currPos = this.transform.position;
			currPos.z = playerPtr.transform.position.z;
			this.transform.position = currPos;
			
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Debug.Log("Died");

			PlayerController currPlayerController = (PlayerController)playerPtr.GetComponent(typeof(PlayerController));
			currPlayerController.killPlayer();

		}
	}
	


}
