using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCivilian : MonoBehaviour {

    private List<Transform> npcs = new List<Transform>();
    private Transform target;
    private bool isTurning = false;

    public void shootAtCivilian(List<Transform> npcs) {
        // Target a civilian first
        this.npcs = npcs;
        target = npcs[Random.Range(0, npcs.Count)];

        // Turn to target (in Update)
        isTurning = true;

        // and shoot
        GetComponent<AudioSource>().Play();
        Invoke("ShootGun", 1.0f);
    }

    private void Update() {
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
        // Shoot the bullet, and if it hits, check if it is a civilian
        if (Physics.Raycast(gunhole.transform.position, forward, out targetHit))
            if (targetHit.transform.gameObject.tag.Equals("Civilian"))
                Destroy(targetHit.transform.gameObject);
    }
}
