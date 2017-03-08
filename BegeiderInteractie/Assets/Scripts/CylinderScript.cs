using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {

    public bool isIdle { get; set; }
    private int crudetimer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isIdle) {
            if (crudetimer < 80) {
                GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * 5;
            } else if (crudetimer <= 160) {
                GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * -5;
            } else {
                crudetimer = 0;
            }
            crudetimer++;
        }
    }

    public void ActionOne() {
        this.transform.GetComponent<Renderer>().material.color = Color.black;
    }
}
