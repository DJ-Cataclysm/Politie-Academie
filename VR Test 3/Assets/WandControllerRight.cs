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

    public GameObject raycastObject;
    RaycastHit objectHit;

    private GameObject objectToMove;
    private Vector3 objectToMovePosition;
    private Vector3 controllerPosition;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update() {
        if (controller == null) {
            Debug.Log("Controller not initialized");
            return;
        }

        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);
        triggerButtonPressed = controller.GetPressUp(triggerButton);

        if (gripButtonDown) {
            Debug.Log("GripButton was just pressed");
        }
        if (gripButtonUp) {
            Debug.Log("Gripbutton was just released");
        }

        if (triggerButtonDown) {
            Debug.Log("triggerButton was just pressed");
            if (controller3D != null)
            {
                controller3D.CheckForHit();
            }
            //CheckForHit();
        }
        if (triggerButtonUp) {
            Debug.Log("triggerbutton was just released");
            objectToMove = null;
            objectToMovePosition = Vector3.zero;
            controllerPosition = Vector3.zero;
        }
        if (triggerButtonPressed) {
            
        }
    }

    //void CheckForHit() {
    //    Vector3 fwd = raycastObject.transform.InverseTransformDirection(Vector3.forward);
    //    Debug.DrawRay(raycastObject.transform.position, fwd * 50, Color.green);
    //    if(Physics.Raycast(raycastObject.transform.position, fwd, out objectHit, 50)) {
    //        print("Gotten something");
    //        GameObject target = objectHit.collider.gameObject;
    //        if (target.tag == "Block") {
    //            objectToMove = target;
    //            objectToMovePosition = target.transform.position;
    //            controllerPosition = trackedObject.transform.position;
    //        }
    //    }
    //}
}
