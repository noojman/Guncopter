using UnityEngine;
using System.Collections;

public class MissileBehavior : MonoBehaviour {

	int t;

	public static float speed;

	public Transform smoke;
	
	Vector3 right = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {
		speed = 20.0f;
	}

	void FixedUpdate() {
		transform.position += right * speed * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (t < 1) {
			t++;
		} else {
			t = 0;
			Instantiate (smoke, new Vector3 (transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
		}

		if (transform.position.x >= 13) {
			Destroy (this.gameObject);
		}
	}
}
