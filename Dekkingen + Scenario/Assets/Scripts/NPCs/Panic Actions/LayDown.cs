using Assets.Scripts.NPCs.Panic_Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class LayDown : MonoBehaviour, IPanic {
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
    //bool turn = false;

    public GameObject target {
        get {
            return _target;
        }
    }

    private void OnEnable() {

        animator.SetBool("Walking2Jump", true);
        //animator.applyRootM-otion = false;
        //turn = true;
        _target = gameObject;
        agent.enabled = false;
    }

    //private void Update() {
    //    if (turn) transform.rotation = Quaternion.Euler(1, 0, 0);
    //    if (transform.rotation.x > 90) turn = false;
    //}
}
