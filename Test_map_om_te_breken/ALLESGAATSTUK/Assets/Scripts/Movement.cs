using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    [SerializeField] private float moveSpeed, jumpSpeed, currentSpeed, jumpcounter = 0;
    private float snappy = 0.5f;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update() {
        //Debug.Log(Time.deltaTime);
        float temp = 0;
        float haha = 256;
        // Moving
        if (Input.GetKey(KeyCode.A)) {
            this.snappy -= 0.1f;
            if (this.snappy < 0) this.snappy = 0;
            if (currentSpeed > 0) {
                currentSpeed *= 0.95f;
            }
            if (GetComponent<Rigidbody>().velocity.x <= -1) {
                temp -= snappy;
            }
            temp -= moveSpeed;
            
        }
        if (Input.GetKey(KeyCode.D)) {
            if (currentSpeed < 0) {
                currentSpeed *= 0.9f;
            }
            temp += moveSpeed;
        }

        if (temp == 0) {
            currentSpeed *= 0.9f;
            if (currentSpeed > 0 && currentSpeed < 0.1 || currentSpeed < 0 && currentSpeed > -0.1) {
                currentSpeed = 0;
            }
        } else {
            currentSpeed += temp;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpcounter++;
            if (jumpcounter < 2) {
                //GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity.x, jumpSpeed, GetComponent<Rigidbody>().velocity.z);
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpSpeed, GetComponent<Rigidbody>().velocity.z);
            } else { jumpcounter = 2; }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1.01f)) {
            jumpcounter = 0;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -5, 5);
        GetComponent<Rigidbody>().velocity = new Vector3(
            currentSpeed,
            GetComponent<Rigidbody>().velocity.y,
            GetComponent<Rigidbody>().velocity.z
        );

    }
}
