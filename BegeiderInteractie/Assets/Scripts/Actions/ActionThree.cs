﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionThree : MonoBehaviour {

    public void Action() {
        this.transform.GetComponent<Renderer>().material.color = Color.white;
    }
}
