using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject npc;

    private float a;
    private float x;
    private float z;

	void Start () {
        //float amountSpawned = Random.Range(2, 10);
        float amountSpawned = 3;
        //print(amountSpawned);

        a = (2 / amountSpawned) * 180;
        //x = 8 * Mathf.Cos(a);
        //z = 8 * Mathf.Sin(a);

        print(a + " " + x + " " + z);

        for (int i = 0; i < amountSpawned; i++) {
            print(a + " " + x + " " + z);
            x = ((i+1)*8) * Mathf.Cos(a);
            z = ((i+1)*8) * Mathf.Sin(a);
            Instantiate(npc, new Vector3(x, 1, z), Quaternion.identity);
        }
	}
}
