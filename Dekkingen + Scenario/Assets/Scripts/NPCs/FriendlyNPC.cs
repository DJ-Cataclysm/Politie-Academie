using Assets.Scripts.NPCs.Panic_Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyNPC : NPC {

    //[SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;

    Animator animator {
        get {
            return GetComponentInChildren<Animator>();
        }
    }

    public bool isInPanic = false;
    int action;
    IPanic panicAction;

    private int landmarkAmount = 0;


    // Set the agent, and set a random first target
    void Start() {
        foreach (Transform child in GameObject.Find("Landmarks").transform) landmarkAmount++;

        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));

        agent.SetDestination(target.transform.position);

        animator.SetBool("Neutral2Walking", true);
    }

    // Agent will move towards his destination, until he's close
    void Update() {
        if (agent.enabled) {
            if (agent.remainingDistance < 2 && !isInPanic) {
                // When he's close enough, find and set a new destination for the poor bugger
                target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
                agent.SetDestination(target.transform.position);
            }
        }

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace"));
        if (agent.speed < 5 && (animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace") || animator.GetCurrentAnimatorStateInfo(0).IsName("walking_inPlace 0"))) {
            Debug.Log("test");
        } 

    }

    protected override void OnDestroy() {
        if (friendlies != null) {
            friendlies.Remove(this);
            all.Remove(this);
        }
        print("Deleted from list! " + this + "  friendlies is: " + friendlies.Count + "   all is: " + all.Count);
    }

    public void Panic() { // at the Disco
        Debug.Log("Panic!");

        if (isInPanic) return;

        isInPanic = true;

        action = Random.Range(1, 5);
        Debug.Log(action);

        switch (action) {
            case 1:
                GetComponent<HideBehindCover>().enabled = true;
                panicAction = GetComponent<HideBehindCover>();
                agent.SetDestination(panicAction.target.transform.position);
                break;
            case 2:
                GetComponent<RunAway>().enabled = true;
                panicAction = GetComponent<RunAway>();
                agent.SetDestination(panicAction.target.transform.position);
                break;
            case 3:
                GetComponent<HideInHouse>().enabled = true;
                panicAction = GetComponent<HideInHouse>();
                agent.SetDestination(panicAction.target.transform.position);
                break;
            case 4:
                GetComponent<LayDown>().enabled = true;
                panicAction = GetComponent<LayDown>();
                break;
        }
    }
}
