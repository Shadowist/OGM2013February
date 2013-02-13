/*
 * DrawCrosshair.cs
 * Author: Steven Burrichter
 * 
 * This script draws a square texture where the 
 * mouse pointer is.
 * 
 * Instructions:
 * 1)Attach script to empty object
 * 2)Assign texture using the Inspector
 * 
 * PNGs carry transparencies!
 */

using UnityEngine;
using System.Collections;

public class DrawCrosshair : MonoBehaviour {
	private Vector2 mousePos = Event.current.mousePosition;
	public Texture crosshairsTexture;
	public Rect mouseTexturePos;
	
	void Start(){
		//Error checking
		if(!crosshairsTexture){
			Debug.LogError ("Assign a Texture in the inspector.");
			return;
		} else {
			Screen.showCursor = false;
		}
	}
	
	void OnGUI(){
		mousePos = Event.current.mousePosition;

		GUI.DrawTexture(mouseTexturePos = new Rect(mousePos.x - (crosshairsTexture.width/2),
     												mousePos.y - (crosshairsTexture.height/2),
		                     						crosshairsTexture.width,
		                     						crosshairsTexture.height), crosshairsTexture);
	}
}
