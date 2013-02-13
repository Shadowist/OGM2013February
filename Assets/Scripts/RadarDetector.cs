/* 
 * Radar Detector.cs
 * Author: Matt Doucette!
 * 
 * Purpose: attach script to the "Radar Cone" object,
 * which is attached to the "Monster." The script will
 * notify the monster whether or not a "runner" is within
 * the scope of the radar.
 * 
 * */


using UnityEngine;
using System.Collections;

public class RadarDetector : MonoBehaviour
{
	public bool playerOneDetect;
	public bool playerTwoDetect;
	public bool playerThreeDetect;
	public bool playerFourDetect;
	
	void Start()
	{
		rigidbody.isKinematic = true;
		playerOneDetect = false;
		playerTwoDetect = false;
		playerThreeDetect = false;
		playerFourDetect = false;
	}
	void OnTriggerStay(Collider collision)
	{
		if(collision.gameObject.name == "Player 1"){
			Debug.Log("Player 1_Stay");
			playerOneDetect = true;
		}
		if(collision.gameObject.name == "Player 2"){
			Debug.Log("Player 2_Stay");
			playerTwoDetect = true;
		}
		if(collision.gameObject.name == "Player 3"){
			Debug.Log("Player 3_Stay");
			playerThreeDetect = true;
		}
		if(collision.gameObject.name == "Player 4"){
			Debug.Log("Player 4_Stay");
			playerFourDetect = true;
		}
	}
	void OnTriggerExit(Collider uncollision)
	{
		if(uncollision.gameObject.name == "Player 1"){
			Debug.Log("Player 1_Unhit");
			playerOneDetect = false;
		}
		if(uncollision.gameObject.name == "Player 2"){
			Debug.Log("Player 2_Unhit");
			playerTwoDetect = false;
		}
		if(uncollision.gameObject.name == "Player 3"){
			Debug.Log("Player 3_Unhit");
			playerThreeDetect = false;
		}
		if(uncollision.gameObject.name == "Player 4"){
			Debug.Log("Player 4_Unhit");
			playerFourDetect = false;
		}	
	}
}
