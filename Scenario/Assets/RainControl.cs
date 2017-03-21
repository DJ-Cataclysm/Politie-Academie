using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainControl : MonoBehaviour {

    public ParticleSystem rain;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Debug.Log("Is uit");
            if (rain.gameObject.activeSelf == true)
                rain.gameObject.SetActive(false);
            else
            {
                Debug.Log("Is aan");
                rain.gameObject.SetActive(true);
            }
                
        }
	}
}
