using Assets.Scripts.NPCs.Panic_Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class HideBehindCover : MonoBehaviour, IPanic {
    private int covermarkAmount = 0;
    private GameObject _target;
    private NavMeshAgent agent {
        get {
            return GetComponent<NavMeshAgent>();
        }
    }
    Animator animator {
        get {
            return GetComponentInChildren<Animator>();
        }
    }

    public GameObject target {
        get {
            return _target;
        }
        private set { }
    }

    private void OnEnable() {
        foreach (Transform child in GameObject.Find("InmapCovers").transform) covermarkAmount++;
        _target = GameObject.Find("Covermark" + UnityEngine.Random.Range(1, (covermarkAmount + 1)));
    }

    // Update is called once per frame
    void Update() {
        if (agent.speed < 10) {
            agent.speed *= 1.01f;
        }
        if (agent.speed > 4) {
            animator.SetBool("Walking2Running", true);
        }
    }
}
