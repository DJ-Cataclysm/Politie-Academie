﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour {
    private Transform directionalLight; //the transform off the light, here we can change the rotation


    public Light light; // the light's Light component, here we can change the intensity


    //an enum for all the possible times
    public enum timeList {
        Day = 1,
        Dim = 2,
        Night = 3,
    }


	// Use this for initialization
	void Start () {
        directionalLight = GetComponent<Transform>(); //gets the transform for the light
	}

    // Update is called once per frame
    void Update() { }

    public void changeTime(timeList time) {
        if(time == timeList.Day) {
            directionalLight.rotation = Quaternion.AngleAxis(90, new Vector3(90, 0, 0));
            light.intensity = 1;
        }else if(time == timeList.Dim) {
            directionalLight.rotation = Quaternion.AngleAxis(22.5f, new Vector3(22.5f, 0, 0));
            light.intensity = 0.25f;
        } else if(time == timeList.Night) {
            directionalLight.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 0));
            light.intensity = 0;
        }
    }
}
