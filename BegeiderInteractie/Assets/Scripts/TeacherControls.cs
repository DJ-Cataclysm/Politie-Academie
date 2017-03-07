using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherControls : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.J)) target.gameObject.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}
