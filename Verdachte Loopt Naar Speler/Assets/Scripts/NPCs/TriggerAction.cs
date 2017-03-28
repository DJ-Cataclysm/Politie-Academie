using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerAction : MonoBehaviour {
    public HitCivilian hitCivilian;
    public MissCivilian missCivilian;
    public TurnToTransform turnToTransform;

    private Transform player;

    private NavMeshAgent agent {
        get {
            return GetComponent<NavMeshAgent>();
        }
    }

    private HostileNPC hostileNPC {
        get {
            return GetComponent<HostileNPC>();
        }
    }

    /// <summary>
    /// !!!!!!!!!!!!!!! READ THIS BEFORE WORKING ON THIS SCRIPT!!!!!!!!!!!!!!!!!!!!
    /// 
    /// This script and its one function (FireAction) are used to trigger specific actions for the currently selected target.
    /// (To be continued)
    /// </summary>
    /// 
    private void Start() {
        player = GameObject.Find("Player").transform;
    }

    public static TriggerAction CreateTriggerAction() {
        return new TriggerAction();
    }

    public void FireAction(string s) {

        switch (s) {
            case "0":
                // Total reset
                break;
            case "1":
                hitCivilian.shootAtCivilian();
                agent.enabled = false;
                hostileNPC.enabled = false;
                Invoke("Panic", 1.5f);
                break;
            case "2":
                missCivilian.shootAtCivilian();
                agent.enabled = false;
                hostileNPC.enabled = false;
                Invoke("Panic", 1.5f);
                break;
            case "3":
                agent.enabled = true;
                hostileNPC.enabled = true;
                agent.destination = player.GetChild(2).transform.position;
                hostileNPC.targetPlayer = true;
                break;
            case "4":
                agent.enabled = true;
                hostileNPC.enabled = true;
                break;
            case "5":
                Panic();
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

    public void Panic() { // at the Disco
        foreach (FriendlyNPC child in NPC.friendlies) child.Panic();
    }
}
