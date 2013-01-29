/*
 * MouseFollow.cs
 * Author: Steven Burrichter
 * 
 * The attached object follows the mouse cursor and is treated as
 * a rigidbody. Also displays various physical attributes
 * in the top left corner.
 * 
 * Movement is defined using forces rather than directly translating.
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MouseFollow : MonoBehaviour {
	public float scaleVelocity = 5.0f;
	public bool releaseOnCollision = true;
	
	private Vector2 mousePos;
	private Vector3 sourceObjectPos;
	
	private float vectorY;
	private float vectorX;
	
	private int numberCollisions = 0;
	private string statusLine;
	
	private bool activeTracking = true;
	
	// Use this for initialization
	void Start () {
		rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
		//rigidbody.drag = 0.8f;
	}
	
	// FixedUpdate
	void FixedUpdate () {
		if(activeTracking)
			FindVectorToTarget();

	}
	
	void FindVectorToTarget () {
		mousePos = Input.mousePosition;
		sourceObjectPos = Camera.mainCamera.WorldToScreenPoint(transform.position);
		
		vectorX = mousePos.x - sourceObjectPos.x;
		vectorY = mousePos.y - sourceObjectPos.y;
		
		Vector3 targetVector = new Vector3(vectorX, vectorY, 0f);
		
		targetVector*=scaleVelocity;
		
		rigidbody.AddForce(targetVector);
	}
	
	void OnGUI () {
		statusLine = "GameObject: " + gameObject.name + 
					"\nMass = " + rigidbody.mass + 
					"\nVelocity = " + rigidbody.velocity + 
					"\nMomentum = " + (rigidbody.mass*rigidbody.velocity.magnitude) + 
					"\nNumber of collisions = " + numberCollisions +
					"\n\nReset Level: Space" +
					"\nQuit Program: Escape";
		
		GUI.Label(new Rect(10,10,200,200), statusLine);
	}
	
	void OnCollisionEnter () {
		numberCollisions++;
		
		if(releaseOnCollision){
			activeTracking = false;
			rigidbody.drag = 0.0f;
		}
	}
	
	void OnMouseOver () {
		activeTracking = true;
	}
}
