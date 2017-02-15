using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{


    float speedForward, speedUp, speedSideways = 0;
    bool forward, up, sideways;
    public float setSpeed = 5;
    public string switchCase;
    public int crudeTimer = 150;
    int crudeTimerSet;

    // Use this for initialization
    void Start()
    {
        crudeTimerSet = crudeTimer;

        switch (switchCase)
        {
            case "right":
                this.speedSideways = (setSpeed * -1);
                this.sideways = true;
                break;
            case "left":
                this.speedSideways = setSpeed;
                this.sideways = true;
                break;
            case "up":
                this.speedUp = (setSpeed * -1);
                this.up = true;
                break;
            case "forward":
                this.speedForward = (setSpeed * -1);
                this.forward = true;
                break;
            case "backward":
                this.forward = true;
                this.speedForward = setSpeed;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.crudeTimer--;
        if (this.crudeTimer >= (crudeTimerSet / 2))
        {
            if (forward)
            {
                GetComponent<Transform>().transform.position -= transform.forward * Time.deltaTime * speedForward;
            }
            else if (sideways)
            {
                GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * speedSideways;
            }
            else if (up)
            {
                GetComponent<Transform>().transform.position -= transform.up * Time.deltaTime * speedUp;
            }
        }
        else
        {
            //if (this.crudeTimer < (crudeTimerSet / 2) && this.crudeTimer >= 0) {
            if (forward)
            {
                GetComponent<Transform>().transform.position += transform.forward * Time.deltaTime * speedForward;
            }
            else if (sideways)
            {
                GetComponent<Transform>().transform.position += transform.right * Time.deltaTime * speedSideways;
            }
            else if (up)
            {
                GetComponent<Transform>().transform.position += transform.up * Time.deltaTime * speedUp;
            }
        }
        if (this.crudeTimer < 0)
        {
            this.crudeTimer = crudeTimerSet;
        }
    }
}
