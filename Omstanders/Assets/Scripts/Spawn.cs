using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject npc;

	void Start () {
        int amountSpawned = Random.Range(2, 10);
        print(amountSpawned);

        for (int i = 0; i < amountSpawned; i++) {
            Instantiate(npc, new Vector3(i * Random.Range(1, 5), 1, i * Random.Range(1, 5)), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
