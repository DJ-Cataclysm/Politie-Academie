using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAgentScript : MonoBehaviour {
    private int landmarkAmountTemp;

    public GameObject target;
    NavMeshAgent agent;
    public int landmarkAmount;
    public bool isIdle = false;

    public Transform player;
    public bool walkToPlayer;

    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    List<Material> mats = new List<Material>();

    void Start() {
        if (this.gameObject.tag != "Target") {
            mats.Add(mat1); mats.Add(mat2); mats.Add(mat3); mats.Add(mat4);
            int randomMat = Random.Range(0, 4);
            this.gameObject.GetComponent<Renderer>().material = mats[randomMat];
        }
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));
    }

    void Update() {
        if (!isIdle) {
            agent.SetDestination(target.transform.position);
            if (agent.remainingDistance < 2 && !walkToPlayer) {
                Debug.Log("New landmark destination");
                target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
                agent.SetDestination(target.transform.position);
            }else if (agent.remainingDistance < 2 && walkToPlayer) {
                WalkToPlayer();
            }
        }
    }

    public void WalkToPlayer() {
        if (!isIdle) {
            agent.SetDestination(player.transform.position);
            Debug.Log("new destination: " + agent.destination);
        }
    }
}
