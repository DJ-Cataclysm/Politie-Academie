using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherControls : MonoBehaviour {

    private bool testBool;

    //public GameObject cube;
    public Camera cubeCam;
    public CubeScript cube;

    //public GameObject cylinder;
    public Camera cylinderCam;
    public CylinderScript cylinder;

    private string target = "cylinder";
    public Text currentCam;

    private void Start() {
        currentCam.text = "Current cam: Cylinder";
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)) TriggerAction(Input.inputString);
        if (Input.GetKeyDown(KeyCode.K)) TriggerAction(Input.inputString);
        if (Input.GetKeyDown(KeyCode.L)) TriggerAction(Input.inputString);
        if (Input.GetKeyDown(KeyCode.I)) TriggerAction(Input.inputString);

        if (Input.GetKey(KeyCode.Alpha1)) target = "cube";
        if (Input.GetKey(KeyCode.Alpha2)) target = "cylinder";

        if (target == "cube") {
            cubeCam.gameObject.SetActive(true);
            cylinderCam.gameObject.SetActive(false);
            currentCam.text = "Current cam: Cube";
        } else if (target == "cylinder") {
            cubeCam.gameObject.SetActive(false);
            cylinderCam.gameObject.SetActive(true);
            currentCam.text = "Current cam: Cylinder";
        }
    }

    public void TriggerAction(string s) {
        switch (target) {
            case "cube":
            cube.isMoving = false;
            cube.FireAction(s);
            break;
            case "cylinder":
            cylinder.isMoving = false;
            cylinder.FireAction(s);
            break;
        }
    }
}
