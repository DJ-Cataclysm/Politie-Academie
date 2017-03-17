using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Flashlight : MonoBehaviour {

    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Touchpad;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;

    private SteamVR_TrackedObject trackedObject = new SteamVR_TrackedObject();
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }

    // Use this for initialization
    void Start () {
        this.trackedObject = GetComponent<SteamVR_TrackedObject>();
        Debug.Log(trackedObject.index.ToString());
        if (trackedObject == null) Debug.Log("Empty TrackedObject");
    }
	
	// Update is called once per frame
	void Update () {
        if (triggerButtonDown)
        {
            //getting the reference to the light Object (it must be taged)
            var myLight = GameObject.FindWithTag("Light");
            //disabling the Light
            if (myLight.GetComponent<Light>().enabled == false) myLight.GetComponent<Light>().enabled = true;
            else myLight.GetComponent<Light>().enabled = false;
        }
    }
}
