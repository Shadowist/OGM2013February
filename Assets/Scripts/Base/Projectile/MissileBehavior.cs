/*
 * Simple projectile behavior
 * Author: Steven Burrichter
 * Latest Revision: 12/19/2012
 *
 * This is testing how components work in scripts. Controller has to be a class variable in order for it to work.
 * I tried declaring it later, but it didn't scope properly.
 * 
 * Steps:
 * 
 * 1) Check for Rigidbody component
 * 2) Create or use Rigidbody component
 * 3) Use constant velocity
 * 4) Destory gameObject upon impact
 */

using UnityEngine;
using System.Collections;

public class MissileBehavior : MonoBehaviour {
	private Rigidbody controller;
	private BoxCollider boxController;

	public Vector3 Velocity = new Vector3(2f,0f,0f);
	public float angularDrag = 9.8f;
	
	private float timeDelay = 2.0f;
	private double lastInterval;
	private float timeNow;
	
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
		
		if(!gameObject.GetComponent<BoxCollider>()){
			print("No BoxCollider connected! Creating component...");
			boxController = gameObject.AddComponent("BoxCollider") as BoxCollider;
		}
		else{
			print("BoxCollider already connected! Using current component...");
			//boxController = BoxCollider;
		}
		boxController.isTrigger = false;
		lastInterval = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		controller.velocity = Velocity;
		controller.angularDrag = angularDrag;
		
		timeNow = Time.realtimeSinceStartup;
		if(timeNow > lastInterval + timeDelay){
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter () {
		//GameObject tmpSpark = Instantiate(Resources.Load("Spark"),transform.position, transform.rotation) as GameObject;
		//tmpSpark.AddComponent<SparkBehavior>();
		Destroy(gameObject);
	}
}
