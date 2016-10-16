using UnityEngine;
using System.Collections;

public class SmokeAnimationBehavior : MonoBehaviour {

	public static float speed;

	Vector3 left = new Vector3(-1, 0, 0);

	// Use this for initialization
	void Start () {
		speed = 10.0f;
	}

	void FixedUpdate () {
		if (HelicopterBehavior.life == 1) {
			transform.position += left * speed * Time.deltaTime;
		}
	}

	void Update() {
		if (transform.position.x <= -13.0f) {
			Destroy(this.gameObject);
		}
	}
}
