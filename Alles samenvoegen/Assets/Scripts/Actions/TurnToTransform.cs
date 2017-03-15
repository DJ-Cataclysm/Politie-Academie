using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToTransform : MonoBehaviour {
    bool turning = false;

    Transform self;
    Transform target;

    private void turn() {
        Quaternion temp = self.rotation;
        rotateToTarget(target, self.position, ref temp, 5f);
        self.rotation = temp;
    }

    // This function rotates the target towards a specific point.
    private void rotateToTarget(Transform target, Vector3 selfPosition, ref Quaternion selfRotation, float slerp) {
        if (target != null) {
            Vector3 lookPosition = target.position - selfPosition;
            lookPosition.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPosition);
            rotation *= Quaternion.Euler(0, 90, 0);
            selfRotation = Quaternion.Slerp(selfRotation, rotation, Time.deltaTime * slerp);
        }
    }

    private void FixedUpdate() {
        if (turning) {
            turn();

            Vector3 targetToCivilian = (target.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(targetToCivilian, transform.forward);
            if (dot < 0.001 && dot > -0.001) {
                turning = false;
            }
        }
    }

    public void startTurning(Transform self, Transform target) {
        this.self = self;
        this.target = target;
        turning = true;
    }
}
