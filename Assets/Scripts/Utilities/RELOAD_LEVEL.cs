/* RELOAD_LEVEL.cs
 * 
 * Author: Steven Burrichter
 * 
 * Purpose: This script gives the player the ability to reset the lvel using
 * a simple keypress. Also, this gives a way to quit the level.
 */

using UnityEngine;
using System.Collections;

public class RELOAD_LEVEL : MonoBehaviour {
	
	public KeyCode resetKey = KeyCode.Space;
	public KeyCode quitKey = KeyCode.Escape;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(resetKey))
			Application.LoadLevel(1);
		else if(Input.GetKey(quitKey))
			Application.Quit();
	}
}
