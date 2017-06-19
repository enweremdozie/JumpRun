using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {

	public float forwardVel = 0f;
	public float fallTime = 0f;
	public GameObject birdPrefab;

	public float moveDuration = 0f;
	public Vector3 initialVel = new Vector3();

	private GameObject masterAudio;

	// Use this for initialization
	void Start () {
		masterAudio = GameObject.FindWithTag ("AudioObject");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerSphere") {
			//Debug.Log("Bird");
			GameObject newBird = (GameObject)GameObject.Instantiate(birdPrefab);
			newBird.transform.position = this.transform.position;

			BirdMove currBirdMove = (BirdMove)newBird.GetComponent(typeof(BirdMove));
			currBirdMove.moveDuration = moveDuration;
			currBirdMove.initialVel = initialVel;
			newBird.tag = "Enemy";
			newBird.layer = LayerMask.NameToLayer("enemy");
			masterAudio.SendMessage ("OtBirdSpawn", SendMessageOptions.DontRequireReceiver);

		}
	}


}
