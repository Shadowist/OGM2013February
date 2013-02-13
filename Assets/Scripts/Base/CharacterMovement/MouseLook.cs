/* MouseLook.cs
 * 
 * Author: Steven Burrichter
 * 
 * Purpose: This is a 2D mouse-looking script. Wherever the *GUI cursor* is (hidden or not),
 * the attached object will rotate and point to it. Also has a basic projectile system attached.
 * 
 * Designer controls:
 * RateOfFire - Controls how quickly objects will be instantiated
 * projectile - Choose a model to act as a projectile
 * target - Choose a target to aim at
 * ProjectileSpeed - Controls how fast the projectile moves
 * 
 * Note: There's probably an easier way using object.LookAt() and locking an axis.
 */

using UnityEngine;
using System.Collections;

public class MouseLook:MonoBehaviour{
	//Mouse controls
	//private float screenCenterHeight = Screen.height/2;
	//private float screenCenterWidth = Screen.width/2;
	private float aimDirection = 0.0f;
	public float RateOfFire = 0.1f;
	public GameObject projectile;
	
	//Directional controls
	float rotationY = -90f;
	float rotationZ = 0f; //Seperate from aimDirection
	Quaternion originalRotation;
	private float opposite;
	private float adjacent;
	private int quadrant;
	public Transform target;
	
	//Projectile controls
	private Vector3 ProjectileInitPos = new Vector3(1.0f, 0.0f, 0.0f);
	private Vector3 ProjectileVelocity = new Vector3(0f, 0f, 0f);
	public float ProjectileSpeed = 10.0f;
		
	// Use this for initialization
	void Start(){
		if(rigidbody)
			rigidbody.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update(){
		FindWeaponAngle();
		
		if(Input.GetMouseButtonDown(0)){InvokeRepeating("FireWeapon", 0.0f, 0.1f);}
		if(Input.GetMouseButtonUp(0)){CancelInvoke("FireWeapon");}
	}
	
	private void FindWeaponAngle(){
		//Calculate opposite and adjacent values
		ProjectileVelocity.y = opposite = target.transform.position.y - transform.position.y;
		ProjectileVelocity.x = adjacent = target.transform.position.x - transform.position.x;
		ProjectileVelocity.z = 0f;
		
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
		print(aimDirection + "\t" + transform.rotation + "\t" + transform.localRotation);
	}
	
	private void FireWeapon(){
		GameObject tempRigidBody = Instantiate(projectile, transform.position-ProjectileInitPos, Quaternion.identity) as GameObject;
		MissileBehavior test = tempRigidBody.AddComponent<MissileBehavior>();
		test.Velocity = Vector3.Normalize(ProjectileVelocity)*ProjectileSpeed;
	}
}
