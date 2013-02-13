using UnityEngine;
using System.Collections;
using XInputDotNetPure;

/*
 * note to self
 * MAKING THIS FUCKING MODULAR IN THE FUTURE >:(
 */

public class Monster : MonoBehaviour {
	//Character Controller
	private Rigidbody controller;
	private BoxCollider collider;
	
	public float playerSpeed = 5.0f;
	public float maxDistance = 100.0f;	
	public float controllerVib = 0.01f;
	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	public GameObject target4;
	
	private float distance1;
	private float distance2;
	private float distance3;
	private float distance4;
	private Vector3 movement = Vector3.zero;
	private float currentTime;
	
	private Vector3 tempPos = Vector3.zero;
	
	//sin wave
	private float sinTime = 0.0f;
	private bool heartBeatVibrate = true;
	
	private GamePadState state;
	
	private int closestTarget = 0;
	
	void Start () {
		/*
		if(!GetComponent("Rigidbody")){
			print("No Rigidbody connected! Creating component...");
			controller = gameObject.AddComponent("Rigidbody") as Rigidbody;
		}else{
			print("Rigidbody already connected! Using current component...");
		}
		
		if(!GetComponent("BoxCollider")){
			print("No BoxCollider connected! Creating component...");
			collider = gameObject.AddComponent("BoxCollider") as BoxCollider;
		}else{
			print("BoxCollider already connected! Using current component...");
		}
		*/		
	}
	
	void Update () {
		currentTime = Time.realtimeSinceStartup;
		
		//Vibration!
		distance1 = Mathf.Abs(target1.transform.position.magnitude - transform.position.magnitude);
		distance2 = Mathf.Abs(target2.transform.position.magnitude - transform.position.magnitude);
		distance3 = Mathf.Abs(target3.transform.position.magnitude - transform.position.magnitude);
		distance4 = Mathf.Abs(target4.transform.position.magnitude - transform.position.magnitude);
		
		if((distance1 < maxDistance) || (distance2 < maxDistance) || (distance3 < maxDistance) || (distance4 < maxDistance)) {
			if((distance1 < distance2) && (distance1 < distance3) && (distance1 < distance4))
				closestTarget = 1;
			if((distance2 < distance1) && (distance2 < distance3) && (distance2 < distance4))
				closestTarget = 2;
			if((distance3 < distance1) && (distance3 < distance2) && (distance3 < distance4))
				closestTarget = 3;
			if((distance4 < distance1) && (distance4 < distance2) && (distance4 < distance3))
				closestTarget = 4;
			
			//Debug.Log (distance1 + "\t" + distance2 + "\t" + distance3 + "\t" + distance4 + "\t" + closestTarget);
			
			switch(closestTarget){
			case 1:
				controllerVib = (maxDistance - distance1)/maxDistance;
				break;
			case 2:
				controllerVib = (maxDistance - distance2)/maxDistance;
				break;
			case 3:
				controllerVib = (maxDistance - distance3)/maxDistance;
				break;
			case 4:
				controllerVib = (maxDistance - distance4)/maxDistance;
				break; 
			}
			
			/*
			if(heartBeatVibrate){
				controllerVib = Mathf.Sin(sinTime);
			}
			sinTime++;
			if(controllerVib == 0)
				heartBeatVibrate = false;
			*/
			
			controllerVib = Mathf.Sin(currentTime*10);
			if(controllerVib <= -0.4)
				controllerVib = 0;
			
			
			
			//Debug.Log (controllerVib);
			
			//GamePad.SetVibration(0,controllerVib,controllerVib);
			GamePad.SetVibration(0,controllerVib, controllerVib);
		}
		
		GamePad.SetVibration(0,0,0);
		
		//Movement!
		movement = Vector3.zero;
		
		state = GamePad.GetState(PlayerIndex.One);
		movement.x = state.ThumbSticks.Left.X;
		movement.z = state.ThumbSticks.Left.Y;
		transform.position += movement*Time.deltaTime*playerSpeed;
		
		tempPos = transform.position;
		if(tempPos.x > 14.5f)
			tempPos.x = 14.5f;
		if(tempPos.x < -14.5f)
			tempPos.x = -14.5f;
		if(tempPos.z > 14.5f)
			tempPos.z = 14.5f;
		if(tempPos.z < -14.5f)
			tempPos.z = -14.5f;
		transform.position = tempPos;
	}
	
	void OnApplicationQuit () {
		GamePad.SetVibration(0,0,0);
	}
}
