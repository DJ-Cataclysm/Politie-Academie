using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAgentScript : MonoBehaviour {
    private int landmarkAmountTemp;

    private bool isInPanic = false;
    private int action;

    List<Material> mats = new List<Material>();


    public GameObject target;
    NavMeshAgent agent;
    public int landmarkAmount;
    public int covermarkAmount;
    public int offmarkCovermarkAmount;
    public int housemarkCoverAmount;
    public bool isIdle = false;

    public Transform player;
    public bool walkToPlayer;

    //public Material mat1;
    //public Material mat2;
    //public Material mat3;
    //public Material mat4;


    void Start() {
        if (this.gameObject.tag != "Target") {
            //mats.Add(mat1); mats.Add(mat2); mats.Add(mat3); mats.Add(mat4);
            //int randomMat = Random.Range(0, 4);
            //this.gameObject.GetComponent<Renderer>().material = mats[randomMat];
        }
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.Find("Landmark" + Random.Range(1, landmarkAmount + 1));
        WalkToLandmark();
    }

    void Update() {
        if (!isIdle && !isInPanic) {
            //agent.SetDestination(target.transform.position);
            if (agent.remainingDistance < 2 && !walkToPlayer) {
                WalkToLandmark();
            }
        }
        if (isInPanic) {
            switch (action) {
                case 1:
                    break;
                case 2:
                    if (agent.remainingDistance < 2) Destroy(gameObject);
                    break;
                case 3:
                    if (agent.remainingDistance < 2) Destroy(gameObject);
                    break;
                case 4:
                    break;
            }
        }
    }

    public void WalkToPlayer() {
        if (!isIdle) {
            target = player.gameObject;
            agent.SetDestination(target.transform.position);
        }
    }

    public void WalkToLandmark() {
        target = GameObject.Find("Landmark" + Random.Range(1, (landmarkAmount + 1)));
        agent.SetDestination(target.transform.position);
    }

    public void Panic() { // at the Disco
        if (isInPanic) return;
        isInPanic = true;

        GetComponent<NavMeshAgent>().speed *= 3;

        action = Random.Range(1, 5);
        Debug.Log(action);

        switch (action) {
            case 1:
                target = GameObject.Find("Covermark" + Random.Range(1, (covermarkAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 2:
                target = GameObject.Find("OffmapCover" + Random.Range(1, (offmarkCovermarkAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 3:
                target = GameObject.Find("HouseCover" + Random.Range(1, (housemarkCoverAmount + 1)));
                agent.SetDestination(target.transform.position);
                break;
            case 4:
                GetComponent<NavMeshAgent>().enabled = false;
                transform.rotation = Quaternion.Euler(90, 0, 0);
                break;
        }
    }
}
