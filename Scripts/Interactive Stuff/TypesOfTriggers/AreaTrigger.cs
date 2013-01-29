/* AreaTrigger.cs
 * 
 * Author: Steven Burrichter
 * 
 * Purpose: An interactive trigger for the player to activate. If any
 * gameObject with TriggerActivator.cs attached touches the AreaTrigger
 * it will activate any attached system.
 * 
 * Required: gameObject with TriggerActivator.cs
 *           An attached system
 *           
 * Designer controls:
 * target - specify a target to activate
 * oneUseOnly - makes the collider-object one time use. Will be destroyed
 * upon use!
 */

using UnityEngine;
using System.Collections;

public class AreaTrigger : MonoBehaviour {

    public GameObject target;
    private bool triggerActive = false;

    public bool oneUseOnly = false;

	// Use this for initialization
	void Start () {
        collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (triggerActive) {
            print("Trigger Active!");

            if (target.GetComponent<Animation>()) {
                if (!target.animation.isPlaying) {
                    target.animation.Play();
                } else { };
            } else {
                print("No animation attached!");
            }
        }

        if (oneUseOnly && triggerActive) {
            Destroy(gameObject);
        }
	}
    
    public void ActivateTrigger() {triggerActive = true;}
    public void DeactivateTrigger() {triggerActive = false;}
}
