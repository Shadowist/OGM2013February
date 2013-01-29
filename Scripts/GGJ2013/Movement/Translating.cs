using UnityEngine;
using System.Collections;

public class Translating : MonoBehaviour {

	//Character Controller
	private Rigidbody controller;
	private BoxCollider collider;
	
	//Movement variables
	public float moveSpeed = 6.0f;
	private Vector3 movement = Vector3.zero;
	
	//Rotation variables
	private Vector3 currentDir = Vector3.zero;
	private float targetDir = 0.0f;
	
	//Physics settings
	public float mass = 1.0f;
	
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
		}else{
			print("Rigidbody already connected! Using current component...");
		}
		
		if(!GetComponent("BoxCollider")){
			print("No BoxCollider connected! Creating component...");
			collider = gameObject.AddComponent("BoxCollider") as BoxCollider;
		}else{
			print("BoxCollider already connected! Using current component...");
		}		
	} 

	void FixedUpdate () {
		
		controller.mass = mass;
		movement = Vector3.zero;
		
		if(Input.GetKey(moveUp))
			movement.z = moveSpeed;
		if(Input.GetKey(moveDown))
			movement.z = -moveSpeed;
		if(Input.GetKey(moveLeft))
			movement.x = -moveSpeed;
		if(Input.GetKey(moveRight))
			movement.x = moveSpeed;
		
		transform.position += movement*Time.deltaTime;
		//End player movement
		
		//Rotation?
		/*
		currentDir = transform.rotation;
		
		if(Input.GetKey(moveRight))
			targetDir = 0.0f;
		else if(Input.GetKey(moveRight) && Input.GetKey(moveUp))
			targetDir = 45.0f;
		else if(Input.GetKey(moveUp))
			targetDir = 90.0f;
		else if(Input.GetKey(moveUp) && Input.GetKey(moveLeft))
			targetDir = 135.0f;
		else if(Input.GetKey(moveLeft))
			targetDir = 180.0f;
		else if(Input.GetKey(moveLeft) && Input.GetKey(moveDown))
			targetDir = 225.0f;
		else if(Input.GetKey(moveDown))
			targetDir = 270.0f;
		else if(Input.GetKey(moveDown) && Input.GetKey(moveRight))
			targetDir = 315.0f;
		
		float testLeft = targetDir - currentDir;*/
	}
}
