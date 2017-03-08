using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {

    public bool isMoving = true;
    private int crudetimer = 0;

    //public ActionOne actionOne;
    //public ActionThree actionTwo;

	// Update is called once per frame
	void Update () {
        if (isMoving) {
            if (crudetimer < 80) {
                GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * 5;
            } else if (crudetimer <= 160) {
                GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * -5;
            } else {
                crudetimer = 0;
            }
            crudetimer++;
        }
    }

    public void FireAction(string s) {
        switch (s) {
            case "j":
            //actionOne.Action();
            break;
            case "k":
            //actionTwo.Action();
            break;
            case "l":
            break;
            case "i":
            break;
        }
    }
}
