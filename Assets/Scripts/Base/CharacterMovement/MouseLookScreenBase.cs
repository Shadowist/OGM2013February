using UnityEngine;
using System.Collections;

/*
 * Next objective
 * Figure out how to get a proper spread
 */

public class MouseLookScreenBase:MonoBehaviour{
	Quaternion originalRotation;
	public GameObject projectile;
	
	//Mouse controls
	private float aimDirection = 0.0f;
	public float rateOfFire = 0.1f;
	
	//Projectile controls
	private Vector3 projectileInitPos = new Vector3(1.0f, 0.0f, 0.0f);
	private Vector3 projectileVelocity = new Vector3(0f, 0f, 0f);
	public float projectileSpeed = 10.0f;
	public float projectileSpread = 50.0f;
	
	//Directional controls
	private float opposite;
	private float adjacent;
	private int quadrant;
	private Vector3 transformScreenPos;
	private Vector2 mousePos;
	
	public Camera cameraController;
	
	void Start(){
		if(rigidbody)
			rigidbody.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	void Update(){
		FindWeaponAngle();
		
		if(Input.GetMouseButtonDown(0)){InvokeRepeating("FireWeapon", 0.0f, 0.1f);}
		if(Input.GetMouseButtonUp(0)){CancelInvoke("FireWeapon");}
	}
	
	void OnGUI(){
		mousePos = Event.current.mousePosition;
	}
	
	void FindWeaponAngle(){
		//Grab screen coordinates
		transformScreenPos = cameraController.WorldToScreenPoint(transform.position);
		
		//Set up variables
		projectileVelocity.x = adjacent = mousePos.x - transformScreenPos.x;
		projectileVelocity.y = opposite = transformScreenPos.y - mousePos.y;
		projectileVelocity.z = 0f;

		//Calculate direction using tan()^-1
		aimDirection = Mathf.Atan(opposite/adjacent);
		aimDirection*=Mathf.Rad2Deg; //Result needs to be converted to degrees
		
		//Determine quadrant
		if(opposite>=0 && adjacent>= 0)
			quadrant = 1;
		else if(opposite>=0 && adjacent<0)
			quadrant = 2;
		else if(opposite<0 && adjacent<0)
			quadrant = 3;
		else if(opposite<0 && adjacent>=0)
			quadrant = 4;
		
		//Convert to 0-360 degrees
		switch(quadrant){
		case 2:
			aimDirection+=180;
			break;
		case 3:
			aimDirection+=180;
			break;
		case 4:
			aimDirection+=360;
			break;
		default:
			break;
		}
		
		//Inject into current gameObject
		Quaternion zQuaternion = Quaternion.AngleAxis(aimDirection, Vector3.forward);
		transform.localRotation = originalRotation*zQuaternion;
	}
	
	private void FireWeapon(){
		
		GameObject tempRigidBody = Instantiate(projectile, transform.position-projectileInitPos, Quaternion.identity) as GameObject;
		MissileBehavior test = tempRigidBody.AddComponent<MissileBehavior>();
		projectileVelocity.x+=Random.Range(-projectileSpread,projectileSpread);
		projectileVelocity.y+=Random.Range(-projectileSpread,projectileSpread);
			
		test.Velocity = Vector3.Normalize(projectileVelocity)*projectileSpeed;
	}
}
