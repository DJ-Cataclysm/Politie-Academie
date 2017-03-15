using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerAction : MonoBehaviour {
    public HitCivilian hitCivilian;
    public MissCivilian missCivilian;
    public TurnToTransform turnToTransform;

    public void FireAction(string s, List<Transform> npcs) {
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(GetComponent<SampleAgentScript>());
        switch (s) {
            case "0":
                // Total reset
                Debug.Log("ButtonPressed: 0");
                break;
            case "1":
                hitCivilian.shootAtCivilian(npcs);
                Debug.Log("ButtonPressed: 1");
                break;
            case "2":
                missCivilian.shootAtCivilian();
                Debug.Log("ButtonPressed: 2");
                break;
            case "3":
                //turnToTransform.startTurning(transform, transform);
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                break;
            case "7":
                break;
            case "8":
                break;
            case "9":
                break;
            default:
                break;
        }
    }
}
