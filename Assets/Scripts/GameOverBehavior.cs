using UnityEngine;
using System.Collections;

public class GameOverBehavior : MonoBehaviour {
	
	float t;
	
	// Use this for initialization
	void Start () {
		t = 0.0f;
		GetComponent<Renderer>().material.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (HelicopterBehavior.life == 0) {
			if (t < 1.0f) {
				t += Time.deltaTime;
				GetComponent<Renderer>().material.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 0.0f), new Color(1.0f, 1.0f, 1.0f, 1.0f), t);
			}
		}
	}
}
