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

    public GameObject target {
        get {
            return _target;
        }
    }

    private void OnEnable() {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        _target = gameObject;
        agent.enabled = false;
    }
}
