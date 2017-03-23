using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class MoveTarget {
        public bool walkToTarget = false;
        public bool runEnabled = false;
        public float currentAcceleration = 0;

        TargetControl targetControl;

        public MoveTarget(TargetControl targetControl) {
            this.targetControl = targetControl;
        }

        Func<float, float, float> getDelta = (a, b) => a - b;

        // This walks the target to you
        public void WalkToTarget(Transform target, Transform transform) {
            // Rotates the target
            Quaternion temp = transform.rotation;
            targetControl.rotateToTarget(target, transform.position, ref temp, 5f);
            transform.rotation = temp;

            // Gets the distance between you and the target
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            //Debug.Log(distanceToTarget + " - " + maxDistance);

            // If the target is outside the maxDistance range, move closer
            if (distanceToTarget > targetControl.maxDistance) {
                // If the walk audio is not playing, play it
                //if (!targetControl.walkAudio.isPlaying) {
                //    targetControl.walkAudio.clip = targetControl.walkAudioClips[UnityEngine.Random.Range(0, targetControl.walkAudioClips.Count)];
                //    targetControl.walkAudio.Play();
                //}

                // A float that holds how many seconds the target takes to get to you
                //float factor = distanceToTarget / (runEnabled ? targetControl.maxMovementSpeed * targetControl.runFactor : targetControl.maxMovementSpeed);

                // The difference in X and Z between you and the target
                float deltaX = getDelta(target.position.x, transform.position.x);
                float deltaZ = getDelta(target.position.z, transform.position.z);

                // Gets how much units the target moves on the X-axis this second.
                //float distanceThisSecondX = deltaX / factor;
                //gets how much units the target moves on the Y-axis this frame.
               // float distanceThisFrameX = distanceThisSecondX * Time.deltaTime;

                // Same as above but then for the Z-axis
                //float distanceThisSecondZ = deltaZ / factor;
                // distanceThisFrameZ = distanceThisSecondZ * Time.deltaTime;

                // Insert acceleration. The acceleration's range is 0 < acceleration < 1
                if (walkToTarget) {
                    if (currentAcceleration < 1) {
                        //currentAcceleration += targetControl.acceleration;
                        if (currentAcceleration > 1) currentAcceleration = 1;
                    }
                } else {
                    if (currentAcceleration > 0) {
                        //currentAcceleration -= targetControl.acceleration;
                        if (currentAcceleration < 0) {
                            currentAcceleration = 0;
                        }
                    }
                }

                // moves the target
                //transform.position += (new Vector3(distanceThisFrameX, 0, distanceThisFrameZ)) * currentAcceleration;
            }
        }
    }
}
