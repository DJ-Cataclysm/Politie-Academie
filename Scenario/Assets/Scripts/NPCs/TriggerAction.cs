using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerAction : MonoBehaviour {
    public HitCivilian hitCivilian;
    public MissCivilian missCivilian;
    public TurnToTransform turnToTransform;

    private Transform player;

    private bool isRunning = false;

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

    private Animator animator {
        get {
            return GetComponentInChildren<Animator>();
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
        animator.SetBool("BNeutral2Walking", true);
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString());
    }

    private void Update() {
        if (agent.speed > 4 && (animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace") || animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace 0"))) {
            animator.SetBool("BWalking2Running", true);
            animator.SetBool("BRunning2Walking", false);
        }

        if (agent.speed < 6 && (animator.GetCurrentAnimatorStateInfo(0).IsName("running_inPlace") || animator.GetCurrentAnimatorStateInfo(0).IsName("running_inPlace 0"))) {
            animator.SetBool("BRunning2Walking", true);
            animator.SetBool("BWalking2Running", false);
        }

        if (isRunning) {
            if (agent.speed < 10) {
                agent.speed *= 1.01f;
            }
        } else {
            if (agent.speed > 3.5f) {
                agent.speed *= 0.99f;
            }
        }
    }

    private void startShooting() {
        animator.SetBool("BNeutral2Walking", false);
        animator.SetBool("BWalking2Running", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("neutral_idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("neutral_idle 0")) {
            animator.SetBool("BShoot2Neutral", false);
            animator.SetBool("BNeutral2Draw", true);
        }

        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace") || animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace 0"))) {
            animator.SetBool("BShoot2Neutral", false);
            animator.SetBool("BWalking2Draw", true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("running_inPlace") || animator.GetCurrentAnimatorStateInfo(0).IsName("running_inPlace 0")) {
            animator.SetBool("BShoot2Neutral", false);
            animator.SetBool("BRunning2Draw", true);
        }


        agent.enabled = false;
        hostileNPC.enabled = false;
        Invoke("Panic", 1.5f);
    }

    public void stopShooting() {
        animator.SetBool("BNeutral2Draw", false);
        animator.SetBool("BWalking2Draw", false);
        animator.SetBool("BRunning2Draw", false);
        animator.SetBool("BShoot2Neutral", true);
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
            startShooting();
            break;
            case "2":
            missCivilian.shootAtCivilian();
            startShooting();
            break;
            case "3":
            agent.enabled = true;
            hostileNPC.enabled = true;
            agent.destination = player.GetChild(2).transform.position;
            hostileNPC.targetPlayer = true;
            break;
            case "4":
            animator.SetBool("BNeutral2Walking", true);
            hostileNPC.targetPlayer = false;
            agent.enabled = true;
            hostileNPC.enabled = true;
            break;
            case "5":
            Panic();
            break;
            case "6":
            isRunning = !isRunning;
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

        //foreach (Transform child in GameObject.Find("NPC Spawner").transform) {
        //    if (child.gameObject.tag.Equals("Civilian")) {
        //        child.GetComponent<SampleAgentScript>().Panic();
        //    }
        //}
    }
}
