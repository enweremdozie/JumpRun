using UnityEngine;
using System.Collections;

public class CopSpawner : MonoBehaviour {

	public GameObject copPrefab;

	public float initialSpeed = 0;
	public float force;
	public float force2;
	public float force3;

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
			Debug.Log("Cop");
			GameObject newCop = (GameObject)GameObject.Instantiate(copPrefab);
			newCop.transform.position = this.transform.position;
			newCop.tag = "Enemy";

			EnemyRunner currCopMove = (EnemyRunner)newCop.GetComponent(typeof(EnemyRunner));
			currCopMove.enemySpeed = initialSpeed;
			currCopMove.force = force;
			currCopMove.force2 = force2;
			currCopMove.force3 = force3;

			masterAudio.SendMessage ("COho", SendMessageOptions.DontRequireReceiver);
			
			
		}
	}

}
