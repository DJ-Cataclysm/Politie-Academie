using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyNPC : NPC {

    [SerializeField] private int landmarkAmount;
    NavMeshAgent agent;
    GameObject target;


    // Set the agent, and set a random first target
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));
    }
	
	// Agent will move towards his destination, until he's close
	void Update () {
        agent.SetDestination(target.transform.position);
        if (agent.remainingDistance < 2) {
            // When he's close enough, find and set a new destination for the poor bugger
            target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
            agent.SetDestination(target.transform.position); ;
        }
    }

    protected override void OnDestroy() {
        if (friendlies != null) {
            friendlies.Remove(this);
            all.Remove(this);
        }
        print("Deleted from list! " + this + "  friendlies is: " + friendlies.Count + "   all is: " + all.Count);
    }
}
