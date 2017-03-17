using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissCivilian : MonoBehaviour {
    private Transform target;
    private bool isTurning = false;

    public void shootAtCivilian() {
<<<<<<< HEAD
        // Pretend to Pew Pew Pew
        GetComponent<AudioSource>().Play();
        Debug.Log("He Shoots, and... he misses. What a dissapointment");
=======

        int loops = 0;
        while (target == null) {
            if (loops > 10) return;
            loops++;
            Transform temp = Spawn.getFriendlyNpcList()[Random.Range(0, Spawn.getFriendlyNpcList().Count)];
            if (temp == null) Debug.Log("nog niemand gevonden");
            if (Vector3.Distance(temp.position, transform.position) > 20) continue;

            RaycastHit info;
            if (Physics.Linecast(transform.position, temp.position, out info, LayerMask.GetMask("Neutral"))) {
                if (!info.transform.tag.Equals("Civilian")) continue;
            }

            if (!temp.gameObject.tag.Equals("Civilian")) continue;

            target = temp;
        }
        if (target == null) return;

        Destroy(target.GetComponent<NavMeshAgent>());
        Destroy(target.GetComponent<SampleAgentScript>());

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
        isTurning = false;
>>>>>>> refs/remotes/origin/TweakenVanTargetSchietOpburger
    }
}
