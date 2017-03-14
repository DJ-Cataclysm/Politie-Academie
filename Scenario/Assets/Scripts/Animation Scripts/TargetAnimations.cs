using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnimations : MonoBehaviour {
    public void surrender() {
        GetComponent<Animation>()["surrender"].speed = 1;
        GetComponent<Animation>()["surrender"].time = 0.0f;
        GetComponent<Animation>().Play("surrender");
    }

    public void aggresive() {
        GetComponent<Animation>()["surrender"].speed = -1;
        GetComponent<Animation>()["surrender"].time = GetComponent<Animation>()["surrender"].length;
        GetComponent<Animation>().Play("surrender");
    }
}
