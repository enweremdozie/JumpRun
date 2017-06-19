using UnityEngine;
using System.Collections;

public class CamraFollow : MonoBehaviour {
	
	public float fallCutoff = 0.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.transform.position.y <= fallCutoff){
			//Debug.Log("Fall: " + fallCutoff);
			this.transform.parent = null;
		}


	}



}
