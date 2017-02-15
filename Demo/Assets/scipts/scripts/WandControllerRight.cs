using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WandControllerRight : MonoBehaviour {

    private EVRButtonId gripButton = EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;


    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;

    public Controller3D controller3D;

    private SteamVR_TrackedObject trackedObject = new SteamVR_TrackedObject();
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }

    // Use this for initialization
    void Start() {
        this.trackedObject = GetComponent<SteamVR_TrackedObject>();
        Debug.Log(trackedObject.index.ToString());
        if (trackedObject == null) Debug.Log("Empty TrackedObject");
    }

    // Update is called once per frame
    void Update() {
        if (this.controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        gripButtonDown = controller.GetPressDown(gripButton);
       // gripButtonPressed = controller.GetPress(gripButton);
        //gripButtonUp = controller.GetPressUp(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        //triggerButtonPressed = controller.GetPress(triggerButton);
        //triggerButtonPressed = controller.GetPressUp(triggerButton);

        if (gripButtonDown) {
            if(controller3D != null) {
                controller3D.ReloadGun();
            }
        }

        //if (gripButtonUp) {}

        if (triggerButtonDown) {
            if (controller3D != null) {
                //controller3D.FireGun();
                if (controller3D.FireGun())
                    RumbleController(0.12f, 500);
            }
        }

        //if (triggerButtonUp) {}

        //if (triggerButtonPressed) {}
    }

    void RumbleController(float duration, float strength)
    {
        StartCoroutine(RumbleControllerRoutine(duration, strength));
    }

    IEnumerator RumbleControllerRoutine(float duration, float strength)
    {
        strength = Mathf.Clamp01(strength);
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup - startTime <= duration)
        {
            int valveStrength = Mathf.RoundToInt(Mathf.Lerp(0, 3999, strength));

            controller.TriggerHapticPulse((ushort)valveStrength);

            yield return null;
        }
    }
}
