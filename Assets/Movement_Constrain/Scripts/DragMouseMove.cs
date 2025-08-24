using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMouseMove : MonoBehaviour {

	private Vector3 mousePosition;
	private Rigidbody2D rb;
	private Vector2 direction;
	private float moveSpeed = 100f;

	public Transform target;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		// on click
		if (Input.GetMouseButton (0)) {
			// get mouse position in world
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// create a normalized direction vector 
			direction = (mousePosition - transform.position).normalized;
			// set velocity
			rb.linearVelocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
		} else if (target != null) {
			// create a normalized direction vector 
			direction = (target.position - transform.position).normalized;
			// set velocity
			rb.linearVelocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
		} else {
			rb.linearVelocity = Vector2.zero;
		}
	}
}
