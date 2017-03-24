using Assets.Scripts.NPCs.Panic_Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class HideInHouse : MonoBehaviour, IPanic {
    private int houseCovermarkAmount = 0;
    private GameObject _target;
    private NavMeshAgent agent {
        get {
            return GetComponent<NavMeshAgent>();
        }
    }
    Animator animator {
        get {
            return GetComponent<Animator>();
        }
    }

    public GameObject target {
        get {
            return _target;
        }
        private set { }
    }

    private void OnEnable() {
        foreach (Transform child in GameObject.Find("HouseCovers").transform) houseCovermarkAmount++;
        _target = GameObject.Find("HouseCover" + UnityEngine.Random.Range(1, (houseCovermarkAmount + 1)));
    }

    // Update is called once per frame
    void Update() {
        if (agent.remainingDistance < 2) Destroy(gameObject);
        if (agent.speed < 10) {
            agent.speed *= 1.01f;
        }
        if (agent.speed > 5) {
            animator.SetBool("Walking2Running", true);
        }
    }
}
