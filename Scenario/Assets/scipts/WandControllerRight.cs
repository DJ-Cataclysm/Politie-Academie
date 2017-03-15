using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WandControllerRight : MonoBehaviour
{

    private EVRButtonId gripButton = EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;


    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;

    public Controller3D controller3D;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    // Use this for initialization
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);
        triggerButtonPressed = controller.GetPressUp(triggerButton);

        if (gripButtonDown)
        {
            if (controller3D != null)
            {
                controller3D.ReloadGun();
            }
        }

        if (gripButtonUp) { }

        if (triggerButtonDown)
        {
            if (controller3D != null)
            {
                controller3D.FireGun();
                SteamVR_Controller.Input((int)controller.index).TriggerHapticPulse(500);
            }
        }

        if (triggerButtonUp) { }

        if (triggerButtonPressed) { }
    }
}
