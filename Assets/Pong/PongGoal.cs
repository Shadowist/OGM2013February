using UnityEngine;
using System.Collections;

public class PongGoal : MonoBehaviour {
	
	private GameObject tempGameController;
	private PongGameControl toGameController;
	
	// Use this for initialization
	void Start () {
		if(!GameObject.Find("GameController"))
			Debug.Log("WARNING: GameController GameObject not found!");
		else
			tempGameController = GameObject.Find("GameController");
		
		if(!tempGameController.GetComponent<PongGameControl>())
			Debug.Log("WARNING: PongGameControl script not found!");
		else
			toGameController = tempGameController.GetComponent<PongGameControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision col) {
		Debug.Log ("Collision detected!");
		
		if(col.gameObject.name == "PongBall"){
			Debug.Log ("Ball hit a goal!");
			
			if(gameObject.name == "Player1Goal"){
				toGameController.IncPlayer2Score();
				Debug.Log ("Player 2 scores!");
			} else if(gameObject.name == "Player2Goal") {
				toGameController.IncPlayer1Score();
				Debug.Log ("Player 1 scores!");
			}
		}
	}
}
