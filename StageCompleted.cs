using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class StageCompleted : MonoBehaviour {

	public bool drawDone = false;
	public Texture gameDone;

	public Texture2D fadeOutTexture;		//The texture will overlay the screen.
	public float fadeSpeed = 0.8f; 			//Speed of the fade
	
	private int drawDepth = -1000;			//The texture's order in the draw heirarchy: lower means on top.
	private float alpha = 1.0f;				//The texture's alpha value between 0 and 1
	public int fadeDir = -1;				//The direction to the fade. in = -1 out = 1

	private GameObject masterAudio;

	// Use this for initialization
	void Start () {
		masterAudio = GameObject.FindWithTag ("AudioObject");
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {

			GlobalData.Score = GlobalData.Score + GlobalData.currScore;
			PlayerController player = (PlayerController)other.gameObject.GetComponent(typeof(PlayerController));
			player.StageEnd();

			if(Application.loadedLevel <= 3){


				Invoke("LoadLevel", 3f);

			}else{
				drawDone = true;
				player.StandStill = true;
				player.MeshAnimator.SetBool("KnockedBack", true);
				masterAudio.SendMessage ("PWin", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void LoadLevel(){
		fadeDir = 1;
		Application.LoadLevel(Application.loadedLevel + 1);
		fadeDir = -1;
	}

	void OnGUI () {
		float x = Screen.width * 0.15f;
		float y = Screen.height * 0.2f;



		if (drawDone == true) {
			GUI.DrawTextureWithTexCoords (new Rect (x, y, Screen.width * 0.7f, Screen.height * 0.7f), gameDone, new Rect (0, 0, 1, 1));
		}
	}

}
