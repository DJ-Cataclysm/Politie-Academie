using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Inputhandler : MonoBehaviour {

    private Transform currentTarget;
    private int currentTargetIndex = 0;

    public UnityEvent SpawnEvent;

    private bool hostilesInScene;

    private void Start() {
        if (NPC.hostiles.Count != 0)
            this.hostilesInScene = true;
    }

    void Update () {
        if(hostilesInScene == false) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                hostilesInScene = true;
                SpawnEvent.Invoke();
            }
        } else { 
            if (currentTarget == null) currentTarget = NPC.hostiles[0].transform;
            // If the keys "1", "2", "3", or "4" is pressed, that key is sent to the current target's script. Depending on the target, they (could) act differently.
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6))
                currentTarget.GetComponent<TriggerAction>().FireAction(Input.inputString);

            // If LeftArrow or RightArrow are pressed, shut off the current target's camera, advance to the next target, and switch on its camera.
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                currentTarget.GetChild(2).transform.gameObject.SetActive(false);
                currentTargetIndex++;
                // A simple "if" to prevent the currentTargetIndex from going out of bounds
                if (currentTargetIndex > (NPC.hostiles.Count - 1)) currentTargetIndex = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                currentTarget.GetChild(2).transform.gameObject.SetActive(false);
                currentTargetIndex--;
                // A simple "if" to prevent the currentTargetIndex from going out of bounds
                if (currentTargetIndex < 0) currentTargetIndex = (NPC.hostiles.Count - 1);
            }

            currentTarget = NPC.hostiles[currentTargetIndex].transform;
            currentTarget.GetChild(2).transform.gameObject.SetActive(true);
        }
    }
}
