using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	
	//Character Controller
	private CharacterController controller;
	private Rigidbody rigidbodyController;
	
	//Movement variables
	public float moveSpeed = 6.0f;
	public Vector3 movement = Vector3.zero;
	private Vector3 lockYAxis = Vector3.zero;
	
	//Setting up for custom controls
	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public KeyCode moveLeft = KeyCode.A;
	public KeyCode moveRight = KeyCode.D;
	
	// Use this for initialization
	void Start () {
		if(!GetComponent("CharacterController")){
			print("No CharacterController connected! Creating component...");
			controller = gameObject.AddComponent("CharacterController") as CharacterController;
		}
		else{
			print("CharacterController already connected! Using current component...");
		}
		
		if(!GetComponent("Rigidbody")){
			print("No Rigidbody connected! Creating component...");
			rigidbodyController = gameObject.AddComponent("Rigidbody") as Rigidbody;
		}
		else{
			print("CharacterController already connected! Using current component...");
		}
		controller.detectCollisions = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Defines how player movement works
		controller = GetComponent<CharacterController>();
		movement = Vector3.zero;
		
		if(Input.GetKey(moveUp))
			movement.z = moveSpeed;
		if(Input.GetKey(moveDown))
			movement.z = -moveSpeed;
		if(Input.GetKey(moveLeft))
			movement.x = -moveSpeed;
		if(Input.GetKey(moveRight))
			movement.x = moveSpeed;
		
		controller.Move(movement * Time.deltaTime);
		//End player movement
		
		
	}
}
