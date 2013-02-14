/* PongGameControl.cs
 * 
 * Author: Steven Burrichter
 * 
 * Information:
 * This is a basic game controller script. Other scripts
 * can search for this centralized script and activate
 * various functions to advance gameplay.
 * 
 * Attach this to an empty GameObject and name it "GameController"!
 */

using UnityEngine;
using System.Collections;

public class PongGameControl : MonoBehaviour {
     public int scoreToWin = 5;
     private int player1Score;
     private int player2Score;


	// Use this for initialization
	void Start () {
          player1Score = 0;
          player2Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
          if (player1Score == scoreToWin) {
               Debug.Log("Player 1 Wins!");
          } else if (player2Score == scoreToWin) {
               Debug.Log("Player 2 Wins!");
          }
	}

     public void IncPlayer1Score() { player1Score++; }
     public void DecPlayer1Score() { player1Score--; }
     public void ResetPlayer1Score() { player1Score = 0; }

     public void IncPlayer2Score() { player2Score++; }
     public void DecPlayer2Score() { player2Score--; }
     public void ResetPlayer2Score() { player2Score = 0; }
}
