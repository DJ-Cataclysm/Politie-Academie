using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherControls : MonoBehaviour {

    public GameObject target;
    private bool testBool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.J)) target.gameObject.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        if (Input.GetKey(KeyCode.Alpha1)) testBool = true;
        if (Input.GetKey(KeyCode.Alpha2)) testBool = false;
        print(testBool);

        //if (testBool) {
        //    GameObject.Find("CubeCam").SetActive(false);
        //    GameObject.Find("TargetCam").SetActive(true);
        //} else {
        //    GameObject.Find("CubeCam").SetActive(true);
        //    GameObject.Find("TargetCam").SetActive(false);
        //}
    }
}
