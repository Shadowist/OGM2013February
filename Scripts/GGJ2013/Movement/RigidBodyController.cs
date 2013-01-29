using UnityEngine;
using System.Collections;

public class RigidBodyController : MonoBehaviour {

	//Character Controller;
	private Rigidbody controller;
	
	//Movement variables
	public float moveSpeed = 6.0f;
	public float mass = 1.0f;
	public Vector3 movement = Vector3.zero;
	private Vector3 lockYAxis = Vector3.zero;
	
	//Setting up for custom controls
	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public KeyCode moveLeft = KeyCode.A;
	public KeyCode moveRight = KeyCode.D;
	
	// Use this for initialization
	void Start () {
		if(!GetComponent("Rigidbody")){
			print("No Rigidbody connected! Creating component...");
			controller = gameObject.AddComponent("Rigidbody") as Rigidbody;
		}
		else{
			print("Rigidbody already connected! Using current component...");
		}
		
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
	}
	
	void FixedUpdate () {
		//Defines how player movement works
		movement = Vector3.zero;
		controller.mass = mass;
		
		if(Input.GetKey(moveUp))
			movement.z = moveSpeed;
		if(Input.GetKey(moveDown))
			movement.z = -moveSpeed;
		if(Input.GetKey(moveLeft))
			movement.x = -moveSpeed;
		if(Input.GetKey(moveRight))
			movement.x = moveSpeed;
		
		rigidbody.AddForce(movement);
		//End player movement
		
		
	}
}
