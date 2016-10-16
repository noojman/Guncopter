using UnityEngine;
using System.Collections;

public class HelicopterBehavior : MonoBehaviour {

	public static float speed;

	public static int life;

	public static bool fireMissile;
	public static bool flyUp;

	public Transform smoke;
	public Transform missile;
	public Transform missileSmoke;
	public Transform smallFire;
	public Transform smallSmoke;
	
	int t;

	bool first;

	Vector3 up = new Vector3(0, 1, 0);

	// Use this for initialization
	void Start () {
		first = true;
		fireMissile = false;
		t = 0;
		life = 2;
		speed = -6.0f;
		flyUp = true;
	}

	void FixedUpdate() {
		if (life == 1) {
			if (flyUp && speed < 6.00f) {
				transform.Rotate (Vector3.forward, 0.60f);
				speed += 0.60f;
			} else if (flyUp == false && speed > -6.00f) {
				transform.Rotate (Vector3.back, 0.75f);
				speed -= 0.75f;
			}
			transform.position += up * speed * Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {
		if (life == 1 && flyUp == true) {
			if (t < 3) {
				t++;
			} else {
				t = 0;
				Instantiate (smoke, new Vector3 (transform.position.x - 1.0f, transform.position.y, 0.0f), Quaternion.identity);
			}
		} else if (life == 1 && flyUp == false) {
			if (t < 10) {
				t++;
			} else {
				t = 0;
				Instantiate (smoke, new Vector3 (transform.position.x - 1.0f, transform.position.y, 0.0f), Quaternion.identity);
			}
		} else if (life == 2) {
			if (t < 35) {
				t++;
			} else {
				t = 0;
				Instantiate (missileSmoke, new Vector3 (transform.position.x - 1.0f, transform.position.y, 0.0f), Quaternion.identity);
			}

			if (Input.GetMouseButtonDown(0)) {
				life = 1;
			}
		} else if (life == 0) {
			if (first) {
				ControllerBehavior.SaveScores();
				RunFire ();
				first = false;
			}
		}

		if (fireMissile && life == 1) {
			Instantiate (missile, new Vector3 (transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
			fireMissile = false;
		}
	}

	void RunFire() {
		Instantiate(smallSmoke, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
		Instantiate(smallFire, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

	}
}
