using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReloader : MonoBehaviour {

    public List<Transform> targets = new List<Transform>();

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform) {
            targets.Add(child);
            print(child);
        }

        activateTargets();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        int activeTargets = 0;
        foreach(Transform target in targets) {
            activeTargets += target.gameObject.activeSelf ? 1 : 0;
        }

        if(activeTargets <= 1) {
            activateTargets();
        }
    }

    private void activateTargets() {
        while (true) {
            int index = Random.Range(0, targets.Count);
            targets[index].gameObject.SetActive(true);

            int activeTargets = 0;
            foreach (Transform target in targets) {
                activeTargets += target.gameObject.activeSelf ? 1 : 0;
            }

            if (activeTargets >= 2) {
                break;
            }
        }
    }
}
