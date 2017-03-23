using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReloader : MonoBehaviour
{
    private bool activatingTargets = false;
    List<Transform> targets = new List<Transform>();

    public int maxTargetsActive;
    public Transform targetHit;

    // Use this for initialization
    void Start() {
        foreach (Transform child in transform) targets.Add(child);

        if (maxTargetsActive <= 0 || maxTargetsActive > targets.Count / 2) maxTargetsActive = 2;

        while (getActiveTargets() < maxTargetsActive) activateTargets();
    }

    private void FixedUpdate() {
        if (getActiveTargets() < maxTargetsActive && !activatingTargets) {
            while (getActiveTargets() < maxTargetsActive) activateTargets();
            targetHit = null;
        }
    }

    public int getActiveTargets() {
        int count = 0;
        foreach (Transform target in targets) count += target.gameObject.activeSelf ? 1 : 0;
        return count;
    }

    public void activateTargets() {
        activatingTargets = true;
        int index = Random.Range(0, targets.Count);
        if (targetHit != null)
            if (!targetHit.Equals(targets[index]))
                targets[index].gameObject.SetActive(true);
        else targets[index].gameObject.SetActive(true);
        activatingTargets = false;
    }
}
