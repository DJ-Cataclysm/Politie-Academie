using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject npc;

    //private float a;
    //private float x;
    //private float z;

	void Start () {
        //float amountSpawned = Random.Range(2, 10);
        float amountSpawned = 20;
        print(amountSpawned);

        //a = (2 / amountSpawned) * 180
        //x = 8 * Mathf.Cos(a);
        //z = 8 * Mathf.Sin(a);
        //print(a + " " + x + " " + z);

        for (int i = 0; i < amountSpawned; i++) {
            //Instantiate(npc, new Vector3(x, 1, z), Quaternion.identity);
            //Instantiate(npc, new Vector3(i * Random.Range(1, 3), 1, i * Random.Range(1,3)), Quaternion.identity);
            string spawnpoint = "Spawnpoint" + Random.Range(1, 5);

            if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                Instantiate(npc, 
                    new Vector3(
                    Random.Range(GameObject.Find("Spawnpoint4").transform.position.x, GameObject.Find("Spawnpoint2").transform.position.x),
                    1 , 
                    GameObject.Find(spawnpoint).transform.position.z), 
                    Quaternion.identity);
            else if (spawnpoint == "Spawnpoint2" || spawnpoint == "Spawnpoint4")
                Instantiate(npc, new Vector3(
                    GameObject.Find(spawnpoint).transform.position.x, 
                    1 , 
                    Random.Range(GameObject.Find("Spawnpoint1").transform.position.z, GameObject.Find("Spawnpoint3").transform.position.z)), 
                    Quaternion.identity);
            //else if (spawnpoint == "Spawnpoint3")
            //    Instantiate(npc, new Vector3(Random.Range(-30, 30), 1 , GameObject.Find(spawnpoint).transform.position.z), Quaternion.identity);
            //else if (spawnpoint == "Spawnpoint4")
            //    Instantiate(npc, new Vector3(GameObject.Find(spawnpoint).transform.position.x, 1, Random.Range(-30, 35)), Quaternion.identity);
            else
                print("Oopsie! Mistake!");

            //Instantiate(npc, new Vector3(GameObject.Find(spawnpoint).transform.position.x, 1, GameObject.Find(spawnpoint).transform.position.z), Quaternion.identity);
        }
    }
}

//return spawnpoint:
// string: "Spawnpoint"+Random.Range(1,5)
