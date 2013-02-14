using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PongBall : MonoBehaviour {
	
	public float Acceleration = 100.0f;
	public float maxSpeed = 10.0f;
	private Vector3 setVelocity = new Vector3(0,0,0);
     private Rigidbody controller;

	// Use this for initialization
	void Start () {
          if (!gameObject.GetComponent<Rigidbody>()) {
               gameObject.AddComponent<Rigidbody>();
          } else {
               controller = rigidbody;
          }

		RandomizeXZVelocity();
		controller.AddForce(setVelocity*Acceleration*Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.SqrMagnitude(controller.velocity) < maxSpeed)
			controller.AddForce(setVelocity*Acceleration*Time.deltaTime);
          Debug.Log(setVelocity);
	}
	
	void RandomizeXZVelocity(){
		while(setVelocity == Vector3.zero){
			setVelocity.x = Random.Range(-10,10);
               setVelocity.y = 0;
			setVelocity.z = Random.Range(-10,10);
		}
	}
	
	void OnCollisionEnter(Collision col){
		ContactPoint contact = col.contacts[0];
		setVelocity = Vector3.Reflect(setVelocity, contact.normal);
	}
}
