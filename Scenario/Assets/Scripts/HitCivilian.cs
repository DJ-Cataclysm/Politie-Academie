using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCivilian : MonoBehaviour {

    public void shootAtCivilian() {
        Transform gunhole = this.transform.GetChild(1);
        Vector3 forward = gunhole.transform.TransformDirection(Vector3.forward);
        RaycastHit targetHit;

        Debug.DrawRay(gunhole.transform.position, forward, Color.red, 50);
        // Shoot the bullet, and if it hits, check if it is a civilian
        if (Physics.Raycast(gunhole.transform.position, forward, out targetHit)) {
            Debug.Log(targetHit);
            if (targetHit.transform.gameObject.tag.Equals("Civilian")) {
                targetHit.transform.gameObject.SetActive(false);
            }
        }
    }
}
