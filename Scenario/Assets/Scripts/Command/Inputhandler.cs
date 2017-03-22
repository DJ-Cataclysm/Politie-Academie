using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputhandler : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha5)) new ExampleOne().Execute();
	}
}
