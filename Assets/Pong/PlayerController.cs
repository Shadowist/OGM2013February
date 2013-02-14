/* PlayerController.cs
 * 
 * Author: Steven Burrichter
 * 
 * Information:
 * This is a simple player controller. I decided on using
 * RigidBodies in case I want the paddles to interact with the game environment.
 * The public variables are adjustable. Use the movementMultiplier in conjuction
 * with the rigidbody mass to find a nice sweet spot for the game. Use moveSpeed
 * to fine tune!
 * 
 * Attach this to the player objects!
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerController : MonoBehaviour {

	//Movement
	public float moveSpeed = 20.0f;
	public float movementMultiplier = 100.0f;
	
	//Key mappings
	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;
	
	// Use this for initialization
	void Start () {
		//rigidbody.freezeRotation = true;
		rigidbody.constraints = RigidbodyConstraints.FreezePositionX |
								RigidbodyConstraints.FreezeRotationX |
								RigidbodyConstraints.FreezeRotationY |
								RigidbodyConstraints.FreezeRotationZ ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(moveUp))
			rigidbody.AddForce(0,0,moveSpeed*movementMultiplier);
		else if(Input.GetKey(moveDown))
			rigidbody.AddForce(0,0,-moveSpeed*movementMultiplier);
	}
}
