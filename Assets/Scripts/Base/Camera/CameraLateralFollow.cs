using UnityEngine;
using System.Collections;

public class CameraLateralFollow : MonoBehaviour {

    public Transform target;
    private Vector3 targetPosition;
    private Vector3 selfPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        selfPosition = transform.position;
        targetPosition = target.transform.position;
        targetPosition.y = selfPosition.y;
        targetPosition.z = selfPosition.z;

        transform.position = targetPosition;
	}
}
