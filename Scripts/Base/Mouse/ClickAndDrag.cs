using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
public class ClickAndDrag : MonoBehaviour {

    public Camera mainCamera;

    private bool moving = false;
    private float posX;
    private float posY;
    private Ray ray;

    private Vector3 selfPosition;

    void Update () {
        if(moving == true){
           //ray  = Camera.main.ScreenPointToRay (Input.mousePosition);
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
           //The Object is 14 away from the camera,
           Debug.Log(ray.GetPoint(14));
           //rigidbody.MovePosition(rigidbody.position + ray.GetPoint(14) * Time.deltaTime);
           selfPosition.x = ray.GetPoint(14).x;
           selfPosition.y = ray.GetPoint(14).y;
           selfPosition.z = 1.1f;

           transform.position = selfPosition;
        }
    }

    void OnMouseDown () {
       moving = true;
    }

    void OnMouseUp () {
        moving = false;

      //Snap to feature
      posX = transform.position.x;
      posX = Mathf.Round(posX);
      if(posX > transform.position.x){
        posX--;
      }
       posY = transform.position.y;
      posY = Mathf.Round(posY);
      if(posY > transform.position.y){
        posY--;
      }

      selfPosition.x = posX + 0.5f;
      selfPosition.y = posY + 0.5f;
      selfPosition.z = transform.position.z;

      transform.position = selfPosition;
    }

    void OnCollisionEnter () {
        rigidbody.isKinematic = true;
    }

    void OnCollisionExit () {
        rigidbody.isKinematic = false;
    }
}