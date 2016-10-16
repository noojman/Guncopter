using UnityEngine;
using System.Collections;

public class BeginBehavior : MonoBehaviour {
	
	float t;

	bool brighten;
	
	// Use this for initialization
	void Start () {
		t = 0.0f;
		brighten = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (HelicopterBehavior.life == 2) {
			if (brighten) {
				t += Time.deltaTime;
				GetComponent<Renderer>().material.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 1.0f), new Color(1.0f, 1.0f, 1.0f, 0.0f), t);
				if (t >= 1.0f) {
					t = 0.0f;
					brighten = false;
				}
			} else {
				t += Time.deltaTime / 0.65f;
				GetComponent<Renderer>().material.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 0.0f), new Color(1.0f, 1.0f, 1.0f, 1.0f), t);
				if (t >= 1.0f) {
					t = 0.0f;
					brighten = true;
				}
			}
		} else {
			if (t < 1.0f) {
				t += Time.deltaTime / 0.35f;
				GetComponent<Renderer>().material.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 1.0f), new Color(1.0f, 1.0f, 1.0f, 0.0f), t);
			}
		}
	}
}
