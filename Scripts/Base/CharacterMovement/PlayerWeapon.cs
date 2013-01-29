using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {
	//Mouse controls
	private float screenCenterHeight = Screen.height/2;
	private float screenCenterWidth = Screen.width/2;
	private float aimDirection = 0.0f;
	public float RateOfFire = 0.1f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Registers mouse clicks
		if(Input.GetMouseButtonDown(0)){InvokeRepeating("FireWeapon", 0.0f, 0.1f);}
		if(Input.GetMouseButtonUp(0)){CancelInvoke("FireWeapon");}
		//End mouse clicks
	}
	
	
	
	void FireWeapon(){
		aimDirection = Mathf.Atan((Input.mousePosition.y - screenCenterHeight)/(Input.mousePosition.x - screenCenterWidth));
		aimDirection*=Mathf.Rad2Deg; //Result needs to be converted to degrees
		
		//Instantiate(TestParticleSystemShoot, transform.position, Quaternion.identity+aimDirection);
		print("Direction = " + aimDirection + " degrees");
	}
}
