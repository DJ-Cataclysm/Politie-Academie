using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller3D))]
public class Player : MonoBehaviour {

    Controller3D controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller3D>();	
	}
}
