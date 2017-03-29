using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputhandler : MonoBehaviour {

    private Transform currentTarget;
    private int currentTargetIndex = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTarget == null) currentTarget = NPC.hostiles[0].transform;
        // If the keys "1", "2", "3", or "4" is pressed, that key is sent to the current target's script. Depending on the target, they (could) act differently.
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6))
            currentTarget.GetComponent<TriggerAction>().FireAction(Input.inputString);

        // If LeftArrow or RightArrow are pressed, shut off the current target's camera, advance to the next target, and switch on its camera.
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
                        //currentTarget.GetChild(0).transform.gameObject.SetActive(false);
            currentTargetIndex++;
            // A simple "if" to prevent the currentTargetIndex from going out of bounds
            if (currentTargetIndex > (NPC.hostiles.Count - 1)) currentTargetIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                        //currentTarget.GetChild(0).transform.gameObject.SetActive(false);
            currentTargetIndex--;
            if (currentTargetIndex < 0) currentTargetIndex = (NPC.hostiles.Count - 1);
        }

        currentTarget = NPC.hostiles[currentTargetIndex].transform;
        //currentTarget.GetChild(0).transform.gameObject.SetActive(true);
    }
}
