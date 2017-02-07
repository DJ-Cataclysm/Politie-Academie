using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReloader : MonoBehaviour {

    List<Transform> targets = new List<Transform>();

    public int maxTargetsActive;

    public int activeTargets;

    // Use this for initialization
    void Start() {
        foreach (Transform child in transform) {
            targets.Add(child);
            print("Next child is: " + child);
        }
        print("Number of targets in the targets list: " + targets.Count);

        if (maxTargetsActive <= 0 || maxTargetsActive > targets.Count / 2) {
            maxTargetsActive = 2;
        }

        this.activeTargets = 0;

        print("activeTargets: " + activeTargets + ", maxTargetsActive: " + maxTargetsActive);
        while (activeTargets < maxTargetsActive) {
            activateTargets(null);
            print("activated Target");
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        if (activeTargets <= 1) {
            activateTargets(null);
        }
    }

    public void activateTargets(Transform targetToExclude) {
        //print("Activating 1 target");

        int index = Random.Range(0, targets.Count);

        if (!targetToExclude.Equals(targets[index])) {
            targets[index].gameObject.SetActive(true);
            activeTargets++;
        }

        print(activeTargets);
        
    }
}
