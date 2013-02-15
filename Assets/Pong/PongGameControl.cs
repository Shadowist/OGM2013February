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
 * If you have a custom ball prefab...connect it in the inspector
 * with Ball.
 */

using UnityEngine;
using System.Collections;

public class PongGameControl : MonoBehaviour {
    public int scoreToWin = 3;
    private int player1Score;
    private int player2Score;
	private string scoreReport;
	private GameObject mainCameraObject;
	private Camera mainCamera;
	
	//GameObjects to be instantiated at run-time
	public Object ball;
	private Vector3 ballPosition = new Vector3(0f,0.8f,0f);
	private Quaternion ballRotation = Quaternion.identity;
	private GameObject ballClone;
	
	// Use this for initialization
	void Start () {
        player1Score = 0;
        player2Score = 0;
		
		mainCameraObject = GameObject.Find("Main Camera");
		mainCamera = mainCameraObject.GetComponent<Camera>();

		ResetBall();
	}
	
	// Update is called once per frame
	void Update () {
		scoreReport = "SCORE" + "\nPlayer 1: " + player1Score + "\nPlayer 2: " + player2Score;
		
		if (player1Score == scoreToWin) {
		   Debug.Log("Player 1 Wins!");
			Destroy(ballClone);
		} else if (player2Score == scoreToWin) {
		   Debug.Log("Player 2 Wins!");
			Destroy(ballClone);
		}
	}
	
	void OnGUI(){
		GUI.Box (new Rect(0,0,100,50), scoreReport);
		
		if(player1Score == scoreToWin)
			GUI.Box (new Rect(mainCamera.pixelWidth/2, mainCamera.pixelHeight/2, 100, 50), "Player 1 Wins!");
		else if(player2Score == scoreToWin)
			GUI.Box (new Rect(mainCamera.pixelWidth/2, mainCamera.pixelHeight/2, 100, 50), "Player 2 Wins!");
	}

	//Other useful functions =]
     public void IncPlayer1Score() { player1Score++; }
     public void DecPlayer1Score() { player1Score--; }
     public void ResetPlayer1Score() { player1Score = 0; }

     public void IncPlayer2Score() { player2Score++; }
     public void DecPlayer2Score() { player2Score--; }
     public void ResetPlayer2Score() { player2Score = 0; }
	
	 public void ResetBall() {
		if(ballClone)
			Destroy(ballClone);
		ballClone = (GameObject)Instantiate(ball, ballPosition, ballRotation);
	}
}
