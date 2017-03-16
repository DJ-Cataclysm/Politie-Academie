using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitCivilian : MonoBehaviour {

    private List<Transform> npcs = new List<Transform>();
    private Transform target;
    private bool isTurning = false;

    public void shootAtCivilian(List<Transform> npcs) {
        // Target a civilian first
        this.npcs = npcs;
        //target = npcs[Random.Range(0, npcs.Count)];

        while (target == null) {
            Transform temp = npcs[Random.Range(0, npcs.Count)];
            if ((Vector3.Distance(temp.position, transform.position) > 20 ||
                Physics.Linecast(transform.position, temp.position, LayerMask.GetMask("Neutral")))) continue;
            if (!temp.gameObject.tag.Equals("Civilian")) continue;
            target = temp;
            //Debug.Log("test, " + target);
        }

        Destroy(target.GetComponent<NavMeshAgent>());
        Destroy(target.GetComponent<SampleAgentScript>());

        // Turn to target (in Update)
        isTurning = true;
        //Debug.Log("isTurning: " + isTurning);

        // and shoot
        Invoke("ShootGun", 1.0f);
    }

    private void FixedUpdate() {
        if (isTurning) {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        }
    }

    private void ShootGun() {
        Transform gunhole = this.transform.GetChild(1);
        Vector3 forward = gunhole.transform.TransformDirection(Vector3.forward);
        RaycastHit targetHit;

        Debug.DrawRay(gunhole.transform.position, forward, Color.red, 50);
        // Shoot the bullet, and if it hits, check if it is a civilian or a target
        if (Physics.Raycast(gunhole.transform.position, forward, out targetHit)) {
            if (targetHit.transform.gameObject.tag.Equals("Civilian") || targetHit.transform.gameObject.tag.Equals("Target")) {
                Destroy(targetHit.transform.gameObject);
            }
        }
        isTurning = false;
    }
}
