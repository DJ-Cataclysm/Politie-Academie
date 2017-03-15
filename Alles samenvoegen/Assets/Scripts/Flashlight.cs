using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //getting the reference to the light Object (it must be taged)
            var myLight = GameObject.FindWithTag("Light");
            //disabling the Light
            if (myLight.GetComponent<Light>().enabled == false)
            {
                myLight.GetComponent<Light>().enabled = true;
            }
            else
            {
                myLight.GetComponent<Light>().enabled = false;
            }
        }
    }
}
