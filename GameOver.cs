using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameOver : MonoBehaviour {
	public Texture gameOver;
	private bool showGame = false;

	private PlayerController _lives;
	public GameObject player;

	// Use this for initialization
	void Start () {
		_lives = (PlayerController)player.GetComponent(typeof(PlayerController));
		//_lives = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalData.lives <= 0) {
			showGame = true;
		}
	}
	void OnGUI () {
		float x = Screen.width * 0.35f;
		float y = Screen.height * 0.4f;

		if (showGame == true) {
			GUI.DrawTextureWithTexCoords (new Rect (x, y, 216, 72), gameOver, new Rect (0, 0, 1, 1));
		}
	}
}