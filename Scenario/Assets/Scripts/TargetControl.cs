using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetControl : MonoBehaviour {
    private bool walkToTarget = false; // Whether or not the target moves towards you

    private AudioSource walkAudio;  // The walk audio

    public Transform target;    // The object the target walks towards
    public float rotationSlerp;     // How fast the target rotates
    public float maxMovementSpeed;  // How fast the target walks in seconds

    public float maxDistance;       // How close the target can get to you before stopping

    // Gets the difference between 2 floats
    Func<float, float, float> getDelta = (a, b) => a - b;

    // Use this for initialization
    void Start() {
        // Gets the audio source component
        walkAudio = GetComponent<AudioSource>();

        // If the movementspeed of the target is equal or less than zero, set it to 1.5
        if (maxMovementSpeed <= 0) {
            maxMovementSpeed = 1.5f;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) walkToTarget = !walkToTarget; // If you press space, it starts or stops walking to you
    }

    void FixedUpdate() {
        // If space has been pressed, walk and rotate
        if (walkToTarget) {
            // Rotates the target
            rotateToTarget();

            // Gets the distance between you and the target
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            //Debug.Log(distanceToTarget + " - " + maxDistance);

            // If the target is outside the maxDistance range, move closer
            if (distanceToTarget > maxDistance) {
                // If the walk audio is not playing, play it
                if (!walkAudio.isPlaying) walkAudio.Play();

                // A float that holds how many seconds the target takes to get to you
                float factor = distanceToTarget / maxMovementSpeed;

                // The difference in X and Z between you and the target
                float deltaX = getDelta(target.position.x, transform.position.x);
                float deltaZ = getDelta(target.position.z, transform.position.z);

                // Gets how much units the target moves on the X-axis this second.
                float distanceThisSecondX = deltaX / factor;
                //gets how much units the target moves on the Y-axis this frame.
                float distanceThisFrameX = distanceThisSecondX * Time.deltaTime;

                // Same as above but then for the Z-axis
                float distanceThisSecondZ = deltaZ / factor;
                float distanceThisFrameZ = distanceThisSecondZ * Time.deltaTime;

                // moves the target
                transform.position += new Vector3(distanceThisFrameX, 0, distanceThisFrameZ);
            }
        }
    }

    // This function rotates the target towards a specific point.
    private void rotateToTarget() {
        if (target != null) {
            Vector3 lookPosition = target.position - transform.position;
            lookPosition.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPosition);
            rotation *= Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSlerp);
        }
    }
}
