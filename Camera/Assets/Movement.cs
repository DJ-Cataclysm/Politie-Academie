using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    public float movementMultiplier;
    public float mouseMultiplier;
    private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        if(movementMultiplier == 0) {
            movementMultiplier = 1;
        }
        if(mouseMultiplier == 0) {
            mouseMultiplier = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        if(mousePosition.Equals(new Vector3(0, 0, 0))) {
            mousePosition = Input.mousePosition;
            goto Movement;
        }

        if (mousePosition.Equals(Input.mousePosition)) {
            goto Movement;
        }

        Vector3 rbRotation = new Vector3(0, -(mousePosition.x - Input.mousePosition.x), 0);

        rbRotation *= mouseMultiplier;

        rb.AddTorque(rbRotation);

        mousePosition = Input.mousePosition;


        Movement:

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0F, verticalMovement);

        movement *= movementMultiplier;

        rb.AddRelativeForce(movement);

        if (Input.GetKeyUp(KeyCode.Space)) {
            rb.position = new Vector3(1, 1, -10);
            rb.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            rb.velocity = new Vector3();
            mousePosition = Input.mousePosition;
        }
    }
}
