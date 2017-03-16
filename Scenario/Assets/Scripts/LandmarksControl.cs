using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarksControl : MonoBehaviour {
    public int landmarkAmount;
    
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
            landmarkAmount++;
            Debug.Log("landmark!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
