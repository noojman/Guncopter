using UnityEngine;
using System.Collections;

public class SplashBehavior : MonoBehaviour {
	
	bool startAnimation;
	float t;
	
	SpriteRenderer myRenderer;
	
	int stage;
	/* 1 : fading in
	 * 2 : fixed
	 * 3 : fading out
	 */
	
	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<SpriteRenderer>();
		myRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
		stage = 1;
		startAnimation = true;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (startAnimation == true && stage == 1) {
			t = 0.0f;
			myRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			startAnimation = false;
		} else if (startAnimation == false && stage == 1) {
			if (t < 1) {
				t += Time.deltaTime / 1.0f;
				myRenderer.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 0.0f), new Color(1.0f, 1.0f, 1.0f, 1.0f), t);
			} else {
				t = 0.0f;
				startAnimation = true;
				stage++;
			}
		}
		
		if (startAnimation == true && stage == 2) {
			t = 0.0f;
			startAnimation = false;
		} else if (startAnimation == false && stage == 2) {
			if (t < 1) {
				t += Time.deltaTime / 1.0f;
			} else {
				t = 0.0f;
				startAnimation = true;
				stage++;
			}
		}
		
		if (startAnimation == true && stage == 3) {
			t = 0.0f;
			myRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			startAnimation = false;
		} else if (startAnimation == false && stage == 3) {
			if (t < 1) {
				t += Time.deltaTime / 1.0f;
				myRenderer.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 1.0f), new Color(1.0f, 1.0f, 1.0f, 0.0f), t);
			} else {
				t = 0.0f;
				startAnimation = true;
				stage++;
				Application.LoadLevel(1);
			}
		}
	}
}