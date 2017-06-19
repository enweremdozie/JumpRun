#pragma strict

var force : float;
var force2: float;
var force3: float;

function Start () {
	
}

function Update () {

	
}

function OnTriggerEnter (other : Collider) {
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


