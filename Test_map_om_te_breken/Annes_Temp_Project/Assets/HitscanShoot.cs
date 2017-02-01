using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 1)) {
            print("There is something in front of the object!");
        }
    }
}
