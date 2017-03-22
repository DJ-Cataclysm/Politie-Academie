﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerAction : MonoBehaviour {
    public HitCivilian hitCivilian;
    public MissCivilian missCivilian;
    public TurnToTransform turnToTransform;
    public SampleAgentScript sampleAgentScript;

    /// <summary>
    /// !!!!!!!!!!!!!!! READ THIS BEFORE WORKING ON THIS SCRIPT!!!!!!!!!!!!!!!!!!!!
    /// 
    /// This script and its one function (FireAction) are used to trigger specific actions for the currently selected target.
    /// (To be continued)
    /// </summary>


    public void FireAction(string s) {

        switch (s) {
            case "0":
                // Total reset
                break;
            case "1":
                hitCivilian.shootAtCivilian();
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<SampleAgentScript>().enabled = false;

                Invoke("Panic", 1.5f);
                break;
            case "2":
                missCivilian.shootAtCivilian();
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<SampleAgentScript>().enabled = false;
                break;
            case "3":
                GetComponent<NavMeshAgent>().enabled = true;
                GetComponent<SampleAgentScript>().enabled = true;
                sampleAgentScript.walkToPlayer = !sampleAgentScript.walkToPlayer;
                if (sampleAgentScript.walkToPlayer) sampleAgentScript.WalkToPlayer(); else sampleAgentScript.WalkToLandmark();
                break;
            case "4":
                GetComponent<NavMeshAgent>().enabled = true;
                GetComponent<SampleAgentScript>().enabled = true;
                break;
            case "5":
                //sampleAgentScript.Panic();
               
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

    private void Panic() {
        foreach (Transform child in GameObject.Find("NPC Spawner").transform) {
            if (child.gameObject.tag.Equals("Civilian")) {
                Debug.Log("test");
                child.GetComponent<SampleAgentScript>().Panic();
            }
        }
    }
}