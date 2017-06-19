using UnityEngine;
using System.Collections;

public class GemRotate : MonoBehaviour {

	public int gemPointValue = 0;
	public float rotateSpeed = 0f;

	// Use this for initialization
	void Start () {
		this.transform.Rotate (new Vector3 (0,Random.Range(0f,100f),0));
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0,rotateSpeed,0));
	}

	void OnCollisionEnter(Collision collision) 
	{
		
		if (collision.gameObject.tag == "Player") 
		{
			GameObject.Destroy(gameObject);
			
		}
		
	}

}
