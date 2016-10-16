using UnityEngine;
using System.Collections;

public class WallBehavior : MonoBehaviour {

	Vector3 left = new Vector3(-1, 0, 0);

	float speed;
	float lvl;

	public Transform floor;

	public static bool goingUp;

	public static float t;
	public static float diff;

	int counter1;
	int counter2;

	// Use this for initialization
	void Start () {
		lvl = 0.05f;
		counter1 = 0;
		counter2 = 0;
		diff = 16.00f;
		int check = Random.Range (1, 4);
		if (check == 1 || check == 2) {
			goingUp = true;
		} else {
			goingUp = false;
		}
		speed = 10.0f;
		t = 0.0f;
		Instantiate (floor, new Vector3 (transform.position.x, transform.position.y - 16.0f, 0.0f), Quaternion.identity);
	}

	void Reset() {
		if (goingUp) {
			transform.position = new Vector3 (13, transform.position.y + Mathf.Sin (t), 0);
		} else {
			transform.position = new Vector3 (13, transform.position.y - Mathf.Sin (t), 0);
		}

		t += lvl;
		WallBehavior.t += lvl;

		if (transform.position.y >= 10.0f) {
			t = 0.00f;
			goingUp = false;
			WallBehavior.goingUp = false;
		} else if (transform.position.y <= 4.0f) {
			t = 0.00f;
			goingUp = true;
			WallBehavior.goingUp = true;
		}

		Instantiate (floor, new Vector3 (transform.position.x, transform.position.y - diff, 0.0f), Quaternion.identity);
	}

	void FixedUpdate() {
		if (HelicopterBehavior.life == 1) {
			transform.position += left * speed * Time.deltaTime;

			if (transform.position.x <= -13.0f) {
				Reset ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log ("Collision!");
		if (collision.gameObject.name == "Helicopter") {
			speed = 0.0f;
			HelicopterBehavior.life = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		if (ControllerBehavior.counter - counter1 ==  5) {
			lvl += 0.0025f;
			counter1 = ControllerBehavior.counter;
		}
		if (ControllerBehavior.counter - counter2 == 10 && diff >= 11.00f) {
			diff -= 0.015f;
			counter2 = ControllerBehavior.counter;
		}
	}
}
