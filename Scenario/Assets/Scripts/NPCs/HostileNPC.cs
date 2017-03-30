using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileNPC : NPC {

    NavMeshAgent agent;
    Landmark target;

    public bool targetPlayer = false;

    private void Awake() {
        NPC.hostiles.Add(this);
        //NPC.all.Add(this);
    }

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        target = Mark.landmarks[Random.Range(0, Mark.landmarks.Count)];
        agent.SetDestination(target.transform.position);
    }

    void Update() {
        if (agent.remainingDistance < 2 && !targetPlayer) {
            // When he's close enough, find and set a new destination for the poor bugger
            target = Mark.landmarks[Random.Range(0, Mark.landmarks.Count)];
            agent.SetDestination(target.transform.position); ;
        }
    }

    private void OnEnable() {
        if (agent != null) {
            targetPlayer = false;
            target = Mark.landmarks[Random.Range(0, Mark.landmarks.Count)];
            agent.SetDestination(target.transform.position);
        }
    }

    protected override void OnDestroy() {
        if (hostiles != null) {
            hostiles.Remove(this);
            all.Remove(this);
        }
        print("Deleted from list! " + this + "  hostiles is: " + hostiles.Count + "   all is: " + all.Count);
    }
}
