using UnityEngine;
using System.Collections;

public class SmokeBehavior : MonoBehaviour {

	Vector3 left = new Vector3(-1, 0, 0);
	Vector3 up = new Vector3(0, 1, 0);

	float sideSpeed;
	float upSpeed;
	float t;

	// Use this for initialization
	void Start () {
		sideSpeed = 10.0f;
		upSpeed = 1.0f;
		t = 0.0f;
	}

	void FixedUpdate() {
		transform.position += up * upSpeed * Time.deltaTime;
		if (HelicopterBehavior.life == 1) {
			transform.position += left * sideSpeed * Time.deltaTime;
		}

		if (transform.position.x <= -13.0f || transform.position.y >= 7.0f) {
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		t += Time.deltaTime / 3.0f;
		GetComponent<Renderer>().material.color = Color.Lerp (new Color(1.0f, 1.0f, 1.0f, 1.0f), new Color(1.0f, 1.0f, 1.0f, 0.0f), t);
	}
}
