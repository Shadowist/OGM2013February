using UnityEngine;
using System.Collections;

//SETTING FORCE TO 6000 IS COOL :D

public class CannonBall : MonoBehaviour {
	private Rigidbody controller;
	public Vector3 Velocity = new Vector3(5f,5f,0f);
	
	private float timeDelay = 1f;
	//private float timeOut = 3f;
	private double lastInterval = 0;
	private float timeNow;
	
	private string statusLine;
	private int numberCollisions;
	
	// Use this for initialization
	void Start () {
		if(!gameObject.GetComponent<Rigidbody>()){
			print("No rigidbody connected! Creating component...");
			controller = gameObject.AddComponent("Rigidbody") as Rigidbody;
		}
		else{
			print("Rigidbody already connected! Using current component...");
			controller = rigidbody;
		}
		
		//controller.velocity = Velocity;
		
		controller.constraints = RigidbodyConstraints.FreezePositionZ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		timeNow = Time.realtimeSinceStartup;
		if(timeNow < lastInterval + timeDelay){
			controller.AddForce(6000,0,0);
		}
		
		/*if(timeNow > lastInterval + timeOut){
			Destroy(gameObject);
		}*/
		
		
		statusLine = "GameObject: " + gameObject.name + 
					"\nMass = " + controller.mass + 
					"\nVelocity = " + controller.velocity + 
					"\nMomentum = " + (controller.mass*controller.velocity.magnitude) + 
					"\nNumber of collisions = " + numberCollisions;
	}
	
	void OnGUI(){
		GUI.Label(new Rect(10,10,200,200), statusLine);
	}
	
	void OnCollisionEnter(){
		numberCollisions++;
	}
}

/*
i am now the player
	
{}

player can 
	move the canonball with the mouse by clicking and dragging
	shoot the canonball by releasing the mouse button
	fire lazers at falling squares with right click
	press spacebar to reset ALL the things
		
GAEM WILL
	countdown to start! 
	scoreboard of blocks shotted with lazers
DONE	trajectory/speed/velocity/PHYSICS CRAP HUD for smart players like Steven
	*/