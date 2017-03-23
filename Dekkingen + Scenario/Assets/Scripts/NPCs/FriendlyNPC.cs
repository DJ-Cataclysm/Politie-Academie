using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyNPC : NPC {

    //[SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;

    bool isInPanic = false;
    int action;

    private int landmarkAmount = 0;
    private int covermarkAmount = 0;
    private int offmapCovermarkAmount = 0;
    private int houseCovermarkAmount = 0;

    // Set the agent, and set a random first target
    void Start() {
        foreach (Transform child in GameObject.Find("Landmarks").transform) landmarkAmount++;
        foreach (Transform child in GameObject.Find("InmapCovers").transform) covermarkAmount++;
        foreach (Transform child in GameObject.Find("OffmapCovers").transform) offmapCovermarkAmount++;
        foreach (Transform child in GameObject.Find("HouseCovers").transform) houseCovermarkAmount++;

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
                agent.SetDestination(target.transform.position); ;
            }
        }

        if (isInPanic) {
            switch (action) {
                case 1:
                    if (agent.speed < 10) {
                        agent.speed *= 1.01f;
                    }
                    break;
                case 2:
                    if (agent.remainingDistance < 2) Destroy(gameObject);
                    if (agent.speed < 10) {
                        agent.speed *= 1.01f;
                    }
                    break;
                case 3:
                    if (agent.remainingDistance < 2) Destroy(gameObject);
                    if (agent.speed < 10) {
                        agent.speed *= 1.01f;
                    }
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
                target = GameObject.Find("Covermark" + Random.Range(1, (covermarkAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 2:
                target = GameObject.Find("OffmapCover" + Random.Range(1, (offmapCovermarkAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 3:
                target = GameObject.Find("HouseCover" + Random.Range(1, (houseCovermarkAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 4:
                agent.enabled = false;
                
                transform.rotation = Quaternion.Euler(90, 0, 0);
                break;
        }
    }
}
