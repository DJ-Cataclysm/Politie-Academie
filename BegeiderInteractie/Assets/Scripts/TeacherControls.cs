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

    private string target;
    public Text currentCam;

    private void Start() {
        currentCam.text = "Current cam: Cylinder";
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)) ActionOne();

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

    public void ActionOne() {
        switch (target) {
            case "cube":
            cube.isIdle = true;
            cube.ActionOne();
            break;
            case "cylinder":
            cylinder.isIdle = true;
            cylinder.ActionOne();
            break;
        }
    }
}
