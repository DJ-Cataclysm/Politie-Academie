using Assets.Scripts.NPCs.Panic_Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyNPC : NPC {

    //[SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;

    public bool isInPanic = false;
    int action;
    Panic panicAction;

    private int landmarkAmount = 0;
    private int offmapCovermarkAmount = 0;


    // Set the agent, and set a random first target
    void Start() {
        foreach (Transform child in GameObject.Find("Landmarks").transform) landmarkAmount++;
        foreach (Transform child in GameObject.Find("OffmapCovers").transform) offmapCovermarkAmount++;

        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));

        agent.SetDestination(target.transform.position);
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

        if (isInPanic) {

            switch (action) {
                case 1:
                    break;
                case 2:
                    if (agent.remainingDistance < 2) Destroy(gameObject);
                    if (agent.speed < 10) {
                        agent.speed *= 1.01f;
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
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
                agent.SetDestination(target.transform.position);
                break;
            case 2:
                target = GameObject.Find("OffmapCover" + Random.Range(1, (offmapCovermarkAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 3:
                GetComponent<HideInHouse>().enabled = true;
                panicAction = GetComponent<HideInHouse>();
                agent.SetDestination(panicAction.target.transform.position);
                break;
            case 4:
                agent.enabled = false;

                transform.rotation = Quaternion.Euler(90, 0, 0);
                break;
        }
    }
}
