using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour {

    //public

    public void FireAction(string s) {
        print("action fired :>");
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
