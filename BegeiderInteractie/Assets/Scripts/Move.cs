using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public int crudetimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if (crudetimer < 150) {
            GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * 5;
        } else if (crudetimer <= 300) {
            GetComponent<Transform>().transform.position -= transform.right * Time.deltaTime * -5;
        } else {
            crudetimer = 0;
        }
        crudetimer++;
    }
}
