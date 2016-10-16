using UnityEngine;
using System.Collections;

public class ControllerBehavior : MonoBehaviour {

	public static int score;

	int highScore;

	public static int counter;

	public static Font myFont;
	
	public static GUIStyle scoreStyle = null;

	float t;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("highscore", 0);
		counter = 0;
		t = 0.0f;
		score = 0;

		myFont = Resources.Load ("DS-DIGI", typeof(Font)) as Font;
		scoreStyle = new GUIStyle ();
		if (Screen.height <= 640 && Screen.width <= 960) {
			scoreStyle.fontSize = 50;
		} else if (Screen.height <= 720 && Screen.width <= 1280) {
			scoreStyle.fontSize = 75;
		} else if (Screen.height <= 1080 && Screen.width <= 1920) {
			scoreStyle.fontSize = 100;
		} else {
			scoreStyle.fontSize = 125;
		}
		scoreStyle.font = myFont;
		scoreStyle.normal.textColor = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		if (HelicopterBehavior.life == 2) {
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.GetKey (KeyCode.Escape)) {
					Application.Quit ();
				}
			}
		}
		if (HelicopterBehavior.life == 0) {
			if (t < 1.0f) {
				t += Time.deltaTime / 2.0f;
			} else {
				Application.LoadLevel(1);
			}
		}
	}

	void OnGUI() {
		if (Screen.height <= 640 && Screen.width <= 960) {
			GUI.Label (new Rect (0, 0, 100, 50), " Score: " + score, scoreStyle);
			GUI.Label (new Rect (0, Screen.height - 50, 100, 50), " Best: " + highScore, scoreStyle);
		} else if (Screen.height <= 720 && Screen.width <= 1280) {
			GUI.Label (new Rect (0, 0, 150, 50), " Score: " + score, scoreStyle);
			GUI.Label (new Rect (0, Screen.height - 75, 150, 50), " Best: " + highScore, scoreStyle);
		} else if (Screen.height <= 1080 && Screen.width <= 1920) {
			GUI.Label (new Rect (0, 0, 200, 50), " Score: " + score, scoreStyle);
			GUI.Label (new Rect (0, Screen.height - 100, 200, 50), " Best: " + highScore, scoreStyle);
		} else {
			GUI.Label (new Rect (0, 0, 250, 50), " Score: " + score, scoreStyle);
			GUI.Label (new Rect (0, Screen.height - 125, 250, 50), " Best: " + highScore, scoreStyle);
		}
	}
	
	public static void SaveScores() {
		PlayerPrefs.SetInt ("yourscore", score);
		int oldHighscore = PlayerPrefs.GetInt ("highscore", 0);
		if (score > oldHighscore) {
			PlayerPrefs.SetInt ("highscore", score);
		}
		PlayerPrefs.Save ();
	}
}
