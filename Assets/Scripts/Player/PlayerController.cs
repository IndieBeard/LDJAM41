using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float carSpeed;
	//[SerializeField]
	//private float steering;
	[SerializeField]
	private Transform min;
	[SerializeField]
	private Transform max;
	private float h;
	Vector3 position;
	Rigidbody2D rb;
	

	// Use this for initialization
	void Start () {
		position = transform.position;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		h = -Input.GetAxis("Horizontal");
		
		position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, min.position.x, max.position.x);
		/* 
		float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
         if(direction >= 0.0f) {
             rb.rotation += h * steering * (rb.velocity.magnitude / 5.0f);
         } else {
             rb.rotation -= h * steering * (rb.velocity.magnitude / 5.0f);
         }
 */
		transform.position = position;
	}
}
