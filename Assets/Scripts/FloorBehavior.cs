using UnityEngine;
using System.Collections;

public class FloorBehavior : MonoBehaviour {

	Vector3 left = new Vector3(-1, 0, 0);
	
	float speed;

	// Use this for initialization
	void Start () {
		speed = 10.0f;
	}

	void FixedUpdate() {
		if (HelicopterBehavior.life == 1) {
			transform.position += left * speed * Time.deltaTime;
			
			if (transform.position.x <= -13) {
				Destroy(this.gameObject);
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
		
	}
}
