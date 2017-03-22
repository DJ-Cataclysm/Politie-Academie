using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileNPC : NPC {

    [SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, 6 + 1));
    }

    // Update is called once per frame
    void Update () {
        agent.SetDestination(target.transform.position);
        if (agent.remainingDistance < 2) {
            // When he's close enough, find and set a new destination for the poor bugger
            target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
            agent.SetDestination(target.transform.position); ;
        }
    }
}
