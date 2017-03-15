using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WandControllerLeft : MonoBehaviour
{
    public GameObject flashlight;

    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Touchpad;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;

    private SteamVR_TrackedObject trackedObject = new SteamVR_TrackedObject();
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }

    // Use this for initialization
    void Start()
    {
        this.trackedObject = GetComponent<SteamVR_TrackedObject>();
        Debug.Log(trackedObject.index.ToString());
        if (trackedObject == null) Debug.Log("Empty TrackedObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        triggerButtonDown = controller.GetPressDown(triggerButton);
        //triggerButtonPressed = controller.GetPress(triggerButton);
        //triggerButtonPressed = controller.GetPressUp(triggerButton);


        //if (gripButtonUp) {}

        if (triggerButtonDown)
        {
            Debug.Log("Triggered");
            if (flashlight.GetComponent<Light>().enabled)
            {
                Debug.Log("Licht uit");
                flashlight.GetComponent<Light>().enabled = false;
            }
            else
            {
                flashlight.GetComponent<Light>().enabled = true;
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
