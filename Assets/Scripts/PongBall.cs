using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PongBall : MonoBehaviour {
	
	public float Acceleration = 100.0f;
	public float maxSpeed = 10.0f;
	private Vector3 setVelocity = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		RandomizeXZVelocity();
		rigidbody.AddForce(setVelocity*Acceleration*Time.deltaTime);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Vector3.SqrMagnitude(setVelocity) < maxSpeed)
			rigidbody.AddForce(setVelocity*Acceleration*Time.deltaTime);
	}
	
	void RandomizeXZVelocity(){
		while(setVelocity == Vector3.zero){
			setVelocity.x = Random.Range(5,10);
			setVelocity.z = Random.Range(5,10);
		}
	}
	
	void OnCollisionEnter(Collision col){
		ContactPoint contact = col.contacts[0];
		setVelocity = Vector3.Reflect(setVelocity, contact.normal);
	}
}
