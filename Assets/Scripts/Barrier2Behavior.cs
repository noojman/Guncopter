using UnityEngine;
using System.Collections;

public class Barrier2Behavior : MonoBehaviour {

	public Transform explosion;
	public Transform smoke;

	public static float speed;

	bool givePoint;
	
	Vector3 left = new Vector3(-1, 0, 0);
	
	// Use this for initialization
	void Start () {
		givePoint = true;
		speed = 10.0f;
		transform.position = new Vector3 (26.0f, Random.Range (-2.75f, 2.75f), 0);
	}
	
	void Reset () {
		transform.position = new Vector3 (13.0f, Random.Range (-2.75f, 2.75f), 0);
		givePoint = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (HelicopterBehavior.life == 1) {
			transform.position += left * speed * Time.deltaTime;
			if (transform.position.x <= -13.0f) {
				Reset();
			}
			if (transform.position.x < -4.5f && transform.position.y < 10 && givePoint) {
				givePoint = false;
				ControllerBehavior.counter++;
				ControllerBehavior.score += 5;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log ("Collision!");
		if (collision.gameObject.name == "Helicopter") {
			speed = 0.0f;
			HelicopterBehavior.life = 0;
		} else if (collision.gameObject.name == "Missile(Clone)") {
			Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			Instantiate(smoke, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			ControllerBehavior.counter++;
			ControllerBehavior.score += 1;
			transform.position = new Vector3(transform.position.x, 30, 0);
			Destroy(collision.gameObject);
		}
	}
}
