using UnityEngine;
using System.Collections;

public class SparkBehavior : MonoBehaviour {
	private float TimeDelay = 2.0f;
	private double LastInterval = 0;
	private float TimeNow;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TimeNow = Time.realtimeSinceStartup;
		if(TimeNow > LastInterval + TimeDelay){
			Destroy(gameObject);
		}
	}
}
