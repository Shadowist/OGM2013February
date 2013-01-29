/* TriggerActivator.cs
 * 
 * Author: Steven Burrichter
 * 
 * Purpose: This turns the attached gameObject into a trigger activator. If 
 * it touches any triggerable collider, it will check for an attached trigger 
 * script (area, button, etc) and then manipulate using the 
 * Activate/DeactivateTrigger functions.
 * 
 * Required: Another object with custom trigger attached
 * 
 * Designer controls: None
 */

using UnityEngine;
using System.Collections;

public class TriggerActivator : MonoBehaviour {

    void OnTriggerEnter(Collider touchedCollider) {
        if (touchedCollider.GetComponent<AreaTrigger>()) {
            print("Triggered!");
            AreaTrigger touchedTrigger = touchedCollider.GetComponent<AreaTrigger>();
            touchedTrigger.ActivateTrigger();
        }
    }

    void OnTriggerExit(Collider touchedCollider) {
        if (touchedCollider.GetComponent<AreaTrigger>()) {
            print("No longer triggered!");
            AreaTrigger touchedTrigger = touchedCollider.GetComponent<AreaTrigger>();
            touchedTrigger.DeactivateTrigger();
        }
    }
}