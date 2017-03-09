using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetControl : MonoBehaviour {
    //private Transform self;

    private bool walkToTarget = false;


    public Transform target;
    public float rotationSlerp;
    public float maxMovementSpeed;

    public float maxDistance;

    static Func<float, float, float> pythagoras = (a, b) => (float)Math.Sqrt(a * a + b * b);

    Func<Vector3, Vector3, float> getDistance = (a, b) => pythagoras(pythagoras(a.x, b.x), pythagoras(a.z, b.z));

    Func<float, float, float> getDelta = (a, b) => a - b;

    // Use this for initialization
    void Start() {
        //self = GetComponent<Transform>();
        if (maxMovementSpeed <= 0) {
            maxMovementSpeed = 1.5f;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) walkToTarget = !walkToTarget;
    }

    void FixedUpdate() {
        if (walkToTarget) {
            rotateToTarget();

            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            Debug.Log(distanceToTarget + " - " + maxDistance);

            if (distanceToTarget > maxDistance) {
                float factor = distanceToTarget / maxMovementSpeed;

                float deltaX = getDelta(target.position.x, transform.position.x);
                float deltaZ = getDelta(target.position.z, transform.position.z);

                float distanceThisSecondX = deltaX / factor;
                float distanceThisFrameX = distanceThisSecondX * Time.deltaTime;

                float distanceThisSecondZ = deltaZ / factor;
                float distanceThisFrameZ = distanceThisSecondZ * Time.deltaTime;

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
