using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectOnInput : MonoBehaviour {
    private bool buttonSelected;

    public EventSystem eventSystem;
    public GameObject selectedObject;

	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw ("Vertical") != 0) {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true; 
        }
	}

    private void OnDisable() {
        buttonSelected = false;
    }
}
