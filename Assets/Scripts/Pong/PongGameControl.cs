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

     void IncPlayer1Score() { player1Score++; }
     void DecPlayer1Score() { player1Score--; }
     void ResetPlayer1Score() { player1Score = 0; }

     void IncPlayer2Score() { player2Score++; }
     void DecPlayer2Score() { player2Score--; }
     void ResetPlayer2Score() { player2Score = 0; }
}
