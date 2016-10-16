using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

	bool first;

	public Sprite buttonDown;
	public Sprite buttonUp;

	// Use this for initialization
	void Start () {
		first = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)) {
				if (first) {
					HelicopterBehavior.fireMissile = true;
					GetComponent<SpriteRenderer>().sprite = buttonDown;
					first = false;
				}
			}
		} else {
			GetComponent<SpriteRenderer>().sprite = buttonUp;
			first = true;
		}
	}
}
