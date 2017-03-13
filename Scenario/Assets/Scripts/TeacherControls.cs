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
    //public Text currentCam;

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
            //currentCam.text = "Current cam: Cube";
        } else if (target == "cylinder") {
            cubeCam.gameObject.SetActive(false);
            cylinderCam.gameObject.SetActive(true);
            //currentCam.text = "Current cam: Cylinder";
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

// Pseudo code for to-do:
//
// Ipv een losse public variabele voor elke enemy is er maar één: "Target"
// Target wordt assigned op runtime: De eerste enemy in de List "npcs"
// 
// Vervolgens roep ik ipv de switch TriggerAction rechtstreeks "target.FireAction(Input.inputString)" aan.
//          (Hiervoor is wel een 'nieuw' script nodig: EnemyScript)
//
// Hoeveelheid enemies moet meegegeven worden en bekend zijn, en variabel zijn.
//
