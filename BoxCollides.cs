using UnityEngine;
using System.Collections;

public class BoxCollides : MonoBehaviour {

	public bool isColliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//isColliding = false;
	}

	void OnTriggerStay(Collider other) {
		isColliding = true;
		
	}

	void OnTriggerExit(Collider other) {
		isColliding = false;
	}


}
