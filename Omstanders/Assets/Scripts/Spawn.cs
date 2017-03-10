using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject npc;
    public float amountSpawned = 40;

    void Start () {
        print("Amount spawned is: " + amountSpawned);

        for (int i = 0; i < amountSpawned; i++) {
            // For each npc to place, select a random starting point.
            string spawnpoint = "Spawnpoint" + Random.Range(1, 5);

            // Depending on the selected starting point, randomize either the X or the Z coordinate, while making sure that the randomized property falls within the range of the other spawnpoints.
            // This causes them to spawn in a nice rectangle (or however the spawnpoints are set up)
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
            // This 'else' should never be reached
            else
                print("Oopsie! Mistake!");
        }
    }
}