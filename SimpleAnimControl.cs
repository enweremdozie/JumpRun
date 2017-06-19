using UnityEngine;
using System.Collections;

public class SimpleAnimControl : MonoBehaviour {

	Animator _anim;



	// Use this for initialization
	void Start () 
	{
		_anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		UpdateAnimation ();


	}

	void UpdateAnimation()
	{
		if (Input.GetAxisRaw ("Fire1") > 0.1f) 
		{
			_anim.SetTrigger ("KnockedBack");
			
		}
		if (Input.GetAxisRaw ("Horizontal") > 0.1f) 
		{
			_anim.SetTrigger ("Run");
			
		}
		if (Input.GetAxisRaw ("Vertical") > 0.1f) 
		{
			_anim.SetTrigger ("Jump");
			
		}
		if (Input.GetAxisRaw ("Vertical") < -0.1f) 
		{
			_anim.SetTrigger ("Faceplant");
			
		}
		if (Input.GetAxisRaw ("Horizontal") < -0.1f) 
		{
			_anim.SetTrigger ("Idle");
			
		}
	}
}
