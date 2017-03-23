using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileNPC : NPC {

    [SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;

    private void Awake() {
        NPC.hostiles.Add(this);
        NPC.all.Add(this);
    }

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));
    }

    void Update () {
        agent.SetDestination(target.transform.position);
        if (agent.remainingDistance < 2) {
            // When he's close enough, find and set a new destination for the poor bugger
            target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
            agent.SetDestination(target.transform.position); ;
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
