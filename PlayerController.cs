using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 0f;

	public bool grounded = false;
	public GameObject bottomCollide;

	private BoxCollides currBottomBox;

	public GameObject playerMesh;
	public Animator MeshAnimator;

	public bool Died = false;
	public float timeDied = float.MaxValue - 100;
	public int health = 4;

	public bool gotHit = false;
	public float lastHitAt = float.MaxValue - 100;

	public bool GameStarted = false;

	public GameObject healthBar;
	AdminC currAdmin;

	public bool jumping = false;

	public Texture scoreTexture;
	public Texture healthTexture;

	public bool ignoreFirstJump = true;

	public int CurrScore = 0;
	private GameObject masterAudio;
	public bool StandStill = false;

	// Use this for initialization
	void Start () {

		currBottomBox = (BoxCollides)bottomCollide.GetComponent(typeof(BoxCollides));
		MeshAnimator = playerMesh.GetComponent<Animator>();

		masterAudio = GameObject.FindWithTag ("AudioObject");
		currAdmin = (AdminC)healthBar.GetComponent(typeof(AdminC));

	}

	public void StageEnd(){

		Invoke ("StageEndDelay", 1f);
		StageEndDelay ();
	}

	public void StageEndDelay(){

		StandStill = true;
		MeshAnimator.SetBool("StageOver", true);
		
	}

	// Update is called once per frame
	void Update () {

		currAdmin.rowNumber = (4 - health);

		if (this.rigidbody.velocity.y >= 0.1) {
			jumping = true;
		} else if (this.rigidbody.velocity.y < -0.1){
			jumping = false;
		}

		MeshAnimator.SetBool("Jumping", jumping);

		if (lastHitAt + 0.2 <= Time.time && Died == false) {
			if(GameStarted == true ){
				moveSpeed = 3f;
			}
		} 

		if(timeDied + 1 <= Time.time){
			moveSpeed = 0;
		}

		if(Died == true){
			int Direction = Random.Range(0,1);

			if(Direction == 0){
				MeshAnimator.SetBool("Died", true);
			}else{
				MeshAnimator.SetBool("KnockedBack", true);
			}


		}


		grounded = currBottomBox.isColliding;
		MeshAnimator.SetBool("Grounded", grounded);

		Vector3 currVel = this.rigidbody.velocity;
		
		currVel.z = moveSpeed;
		
		//this.rigidbody.

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

		if(grounded == true && Input.GetKeyDown(KeyCode.Space) && !Died && GameStarted == true){

			if(ignoreFirstJump == false){
				currVel.y += 6f;
				masterAudio.SendMessage ("PJump", SendMessageOptions.DontRequireReceiver);
			}

			ignoreFirstJump = false;
			//Debug.Log("Space");
		}
		
		
		if (Input.GetKeyDown(KeyCode.W)) {
			
			//StartGame();
			//Debug.Log("W");
			
		}
		
		
		if (Input.GetKey(KeyCode.A)) {
			
			//currVel.z = -5f;
			
			
			//Debug.Log("A");
			
		}
		
		
		if (Input.GetKeyDown(KeyCode.S)) {
			
			///Debug.Log("S");
			
		}
		
		
		if (Input.GetKey(KeyCode.D)) {
			
			//killPlayer();
			
			
			//Debug.Log("D");
			
		}
		
		this.rigidbody.velocity = currVel;
		
		if (StandStill == true) {
			Vector3 currVelStay = this.rigidbody.velocity;
			currVelStay.x = 0;
			currVelStay.z = 0;
			this.rigidbody.velocity = currVelStay;
		}


	}

	public void killPlayer(){

		if (GlobalData.lives <= 0) {
			moveSpeed = 0.8f;
			timeDied = Time.time;
			GameObject.Destroy (healthBar);
			health = 0;
		} else {
			GlobalData.lives = GlobalData.lives - 1;
			masterAudio.SendMessage ("PDied", SendMessageOptions.DontRequireReceiver);
			Invoke("ResetLevel", 2f);
		}
		Died = true;
		StandStill = true;
	}



	void ResetLevel(){
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnCollisionEnter(Collision collision) {



		if (collision.gameObject.CompareTag("Enemy")) {
			health--;
			//Debug.Log("Hit" + health);

			gotHit = true;
			lastHitAt = Time.time;
			moveSpeed = 2;
			masterAudio.SendMessage ("PGotHit", SendMessageOptions.DontRequireReceiver);
					
			if(health <= 0){
				killPlayer();
			}

		}

		if (collision.gameObject.CompareTag("Loot")) {
			GemRotate currLoot = (GemRotate)collision.gameObject.GetComponent(typeof(GemRotate));
			GlobalData.currScore += currLoot.gemPointValue;
			masterAudio.SendMessage ("OtJingle", SendMessageOptions.DontRequireReceiver);
		}

	}

	public void StartGame(){
		moveSpeed = 3f;
		MeshAnimator.SetBool("Moving", true);
		GameStarted = true;
	}

	void OnGUI() {
		
		GUIStyle font = new GUIStyle ();
		font.normal.textColor = new Color (0f, 0f, 0f);
		font.fontStyle = FontStyle.Bold;
		
		GUI.DrawTextureWithTexCoords(new Rect(20,20,500,30), scoreTexture, new Rect(0,0,1,1));
		GUI.Label (new Rect (320,28,200,50), "" + GlobalData.currScore.ToString(), font);



		if(Died == false){
			float offset = (float)(health - 1) * 0.25f;
			GUI.DrawTextureWithTexCoords(new Rect(Screen.width - 75, Screen.height - 110,50,100), healthTexture, new Rect(0,offset,1,0.25f));
		}
	}

}
