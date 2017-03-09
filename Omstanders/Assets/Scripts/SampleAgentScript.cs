using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAgentScript : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, 5));
    }
	
	void Update () {
        agent.SetDestination(target.transform.position);
        if (agent.remainingDistance < 2) {
            target = GameObject.Find("Landmark" + Random.Range(1, 5));
            agent.SetDestination(target.transform.position);
        }
	}
}
