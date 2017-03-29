using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissCivilian : MonoBehaviour {
    private Transform target;
    private bool isTurning = false;

    public void shootAtCivilian() {

        int loops = 0;
        while (target == null) {
            if (loops > 10) {
                GetComponent<TriggerAction>().stopShooting();
                return;
            }
            loops++;
            Transform temp = NPC.friendlies[Random.Range(0, NPC.friendlies.Count)].transform;
            if (temp == null) break;
            if (Vector3.Distance(temp.position, transform.position) > 20) continue;

            RaycastHit info;
            if (Physics.Linecast(transform.position, temp.position, out info, LayerMask.GetMask("Neutral"))) {
                if (!info.transform.tag.Equals("Civilian")) continue;
            }

            if (!temp.gameObject.tag.Equals("Civilian")) continue;

            target = temp;
        }
        if (target == null) {
            GetComponent<TriggerAction>().stopShooting();
            return;
        }

        Destroy(target.GetComponent<NavMeshAgent>());
        Destroy(target.GetComponent<FriendlyNPC>());

        // Turn to target (in Update)
        isTurning = true;

        Invoke("stopTurning", 1.0f);
    }

    private void FixedUpdate() {
        if (isTurning) {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        }
    }

    private void stopTurning() {
        GetComponent<AudioSource>().Play();
        GetComponent<TriggerAction>().stopShooting();
        isTurning = false;
    }
}
