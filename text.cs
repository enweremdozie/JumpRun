using UnityEngine;
using System.Collections;

public class text : MonoBehaviour {
	public Texture[] textBoxArray;
	public Texture[] textArray;
	public int textCurr = 0;

	public bool visibleGui = true;
	private PlayerController _lives;
	public GameObject player;

	private text _text;

	public Texture2D fadeOutTexture;		//The texture will overlay the screen.
	public float fadeSpeed = 0.8f; 			//Speed of the fade
	
	private int drawDepth = -1000;			//The texture's order in the draw heirarchy: lower means on top.
	private float alpha = 1.0f;				//The texture's alpha value between 0 and 1
	public int fadeDir = -1;				//The direction to the fade. in = -1 out = 1

	// Use this for initialization
	void Start () {
		_text = GetComponent<text> ();
		//_lives = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		_lives = (PlayerController)player.GetComponent(typeof(PlayerController));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") && visibleGui) {
			textCurr ++;
		}

		if (textCurr >= textArray.Length) {
			visibleGui = false;
			_lives.StartGame();

		}
	}

	void OnGUI() {
	
		float x = 250;
		float y = 225;



			if (visibleGui) {


				GUI.DrawTextureWithTexCoords (new Rect (x, y, 216, 72), textBoxArray [0], new Rect (0, 0, 1, 1));
				//GUI.Label (new Rect (320,28,200,50), "" + playerScore.ToString(), font);

				GUI.DrawTextureWithTexCoords (new Rect (x, y, 216, 72), textArray [textCurr], new Rect (0, 0, 1, 1));
				//GUI.DrawTextureWithTexCoords(new Rect(x,y,216,72), textWord, new Rect(0,0,1,1));

			} else {

				//fade in/out the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
				alpha += fadeDir * fadeSpeed * Time.deltaTime;
				// force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
				alpha = Mathf.Clamp01 (alpha);

				//Set colour of our GUI (or texture). All colour values remain the same & the Alpha is set to the alpha variable.
				GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);	//Set the alpha colour
				GUI.depth = drawDepth;															//Make the black texture render on top (drawn last)
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); //draw the texture to fit the screen area


			}
	}

	}