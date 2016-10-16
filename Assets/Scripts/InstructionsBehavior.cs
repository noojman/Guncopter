using UnityEngine;
using System.Collections;

public class InstructionsBehavior : MonoBehaviour {

	float t;

	// Use this for initialization
	void Start () {
		t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (HelicopterBehavior.life != 2) {
			if (t < 1.0f) {
				t += Time.deltaTime / 0.35f;
				GetComponent<Renderer>().material.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 1.0f), new Color(1.0f, 1.0f, 1.0f, 0.0f), t);
			}
		}
	}
}
