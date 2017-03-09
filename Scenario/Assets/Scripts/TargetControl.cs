using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetControl : MonoBehaviour {
    private bool walkToTarget = false; //whether or not the target moves towards you


    public Transform target;    //the object the target walks towards
    public float rotationSlerp;     //how fast the target rotates
    public float maxMovementSpeed;  //how fast the target walks in seconds

    public float maxDistance;       //how close the target can get to you before stopping

    //gets the difference between 2 floats
    Func<float, float, float> getDelta = (a, b) => a - b;

    // Use this for initialization
    void Start() {
        //if the movementspeed of the target is equal or less than zero, set it to 1.5
        if (maxMovementSpeed <= 0) {
            maxMovementSpeed = 1.5f;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) walkToTarget = !walkToTarget; //if you press space, it starts or stops walking to you
    }

    void FixedUpdate() {
        //if space has been pressed, walk and rotate
        if (walkToTarget) {
            //rotates the target
            rotateToTarget();

            //gets the distance between you and the target
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            //Debug.Log(distanceToTarget + " - " + maxDistance);

            //if the target is outside the maxDistance range, move closer
            if (distanceToTarget > maxDistance) {
                //a float that holds how many seconds the target takes to get to you
                float factor = distanceToTarget / maxMovementSpeed;

                //the difference in X and Z between you and the target
                float deltaX = getDelta(target.position.x, transform.position.x);
                float deltaZ = getDelta(target.position.z, transform.position.z);

                //gets how much units the target moves on the X-axis this second.
                float distanceThisSecondX = deltaX / factor;
                //gets how much units the target moves on the Y-axis this frame.
                float distanceThisFrameX = distanceThisSecondX * Time.deltaTime;

                //same as above but then for the Z-axis
                float distanceThisSecondZ = deltaZ / factor;
                float distanceThisFrameZ = distanceThisSecondZ * Time.deltaTime;

                //moves the target
                transform.position += new Vector3(distanceThisFrameX, 0, distanceThisFrameZ);
            }
        }
    }

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
