/*
 * TimeOut.cs
 * Author: Steven Burrichter
 * 
 * Rev1: This is a simple script to destory the attached gameObject after a period of time.
 * Rev2: Added fading using the Transparent/Diffuse shader
 */

using UnityEngine;
using System.Collections;

public class TimeOut : MonoBehaviour {
	private bool collisionDetected = false;
	public bool useGravity = true;
	
	public float timeFade = 5f;
	public float timeOut = 10f;
	private double lastInterval;
	private float timeNow;
	
	private Color tempColor;
	private float materialTransparancy = 1.0f;
	public float magnitudeTolerance = 0.01f;
		
	// Use this for initialization
	void Start () {
		//Store original material
		tempColor = renderer.material.color;
		rigidbody.useGravity = useGravity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(collisionDetected){
			
			//Check the current time
			timeNow = Time.realtimeSinceStartup;
			
			//Start fading either below a certain velocity magnitude or over a period of time
			if(rigidbody.velocity.magnitude <= magnitudeTolerance || (timeNow > lastInterval+timeOut)){
				
				if(timeNow > lastInterval + timeFade){
					renderer.material.shader = Shader.Find("Transparent/Diffuse");
					renderer.material.color = new Color(tempColor.r,tempColor.g,tempColor.b,materialTransparancy);
					
					materialTransparancy-=1f*Time.deltaTime;
				}
				
				//Destroy if transparency is too clear
				if(materialTransparancy <= 0.00000001f)
					Destroy(gameObject);
			}
		}
		
	}
	
	void OnCollisionEnter () {
		collisionDetected = true;
		rigidbody.useGravity = true;
	}
}
