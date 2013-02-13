using UnityEngine;
using System.Collections;

/*
 * PlayerMovement
 * Author: Steven Burrichter
 * Latest Revision: December 7, 2012
 * 
 * Current Implementation:
 * Attach to the player character to generate standard movement
 * A - Move left
 * D - Move right
 * Space - Jump
 * 
 * Also registers mouse clicks and calculates the direction (radians)
 * Converts from Radians to Degrees
 * Prints out the direction to the mouse in degrees from the +x axis
 * 
 * Future Implementations:
 * Customizable mappings
 * Basic attack
 * Pending
 */

public class PlayerMovement : MonoBehaviour {
	
	//Character Controller
	private CharacterController controller;
	
	//Movement variables
	public float moveSpeed = 6.0f;
	public float jumpSpeed = 8.0f;
	public int jumpTime = 8;
	public float vertSpeed = 0.0f;
	public float gravity = 9.8f;
	public Vector3 movement = Vector3.zero;
		
	//Setting up for custom controls
	public KeyCode moveLeft = KeyCode.A;
	public KeyCode moveRight = KeyCode.D;
	public KeyCode moveJump = KeyCode.Space;
	
	
	//Use this for initialization
	void Start (){
		if(!GetComponent("CharacterController")){
			print("No CharacterController connected! Creating component...");
			controller = gameObject.AddComponent("CharacterController") as CharacterController;
		}
		else{
			print("CharacterController already connected! Using current component...");
		}
	}
	
	//Update is called once per frame
	void FixedUpdate () {
		
		//Defines how player movement works
		controller = GetComponent<CharacterController>();
		movement.x = 0;
		
		if(Input.GetKey(moveLeft))
			movement.x = -moveSpeed;
		else if(Input.GetKey(moveRight))
			movement.x = moveSpeed;
		
		if(controller.isGrounded){
			vertSpeed = 0.0f;
			
			if(Input.GetKey(moveJump)){
				vertSpeed = jumpSpeed;
			}
		}
		
		vertSpeed -= gravity*Time.deltaTime;
		movement.y = vertSpeed;
	
		controller.Move(movement * Time.deltaTime);
		//End player movement
		
		
	}
	
	//Functions: Set key mappings 
	void SetMoveLeft(KeyCode Temp){moveLeft = Temp;}
	void SetMoveRight(KeyCode Temp){moveRight = Temp;}
	void SetMoveJump(KeyCode Temp){moveJump = Temp;}
}
