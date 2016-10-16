using UnityEngine;
using System.Collections;

public class TouchBoxBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)) {
				HelicopterBehavior.flyUp = true;
			}
		} else {
			HelicopterBehavior.flyUp = false;
		}
	}
}
