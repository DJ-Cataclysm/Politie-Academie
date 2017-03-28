using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileNPC : NPC {

    [SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;

    public bool targetPlayer = false;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    void Update () {
        if (agent.remainingDistance < 2 && !targetPlayer) {
            // When he's close enough, find and set a new destination for the poor bugger
            target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
            agent.SetDestination(target.transform.position);
        }
    }

    private void OnEnable() {
        targetPlayer = false;
        target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
        agent.SetDestination(target.transform.position);
    }

    protected override void OnDestroy() {
        if (hostiles != null) {
            hostiles.Remove(this);
            all.Remove(this);
        }
        print("Deleted from list! " + this + "  hostiles is: " + hostiles.Count + "   all is: " + all.Count);
    }
}
