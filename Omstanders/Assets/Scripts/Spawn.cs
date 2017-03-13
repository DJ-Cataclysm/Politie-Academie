using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour {

    public Transform npc;
    public Transform enemy;
    public Transform parent;

    List<Transform> npcs = new List<Transform>();

    public float amountNormalSpawned = 40;
    public float amountEnemySpawned = 0;
    public float amountIdleSpawned = 0;
    private float amountToSpawn;

    void Start () {
        amountToSpawn = amountNormalSpawned + amountEnemySpawned + amountIdleSpawned;
        print("Amount spawned is: " + amountToSpawn + ". Normal is: " + amountNormalSpawned + ". Idle is: " + amountIdleSpawned + ". Enemy is: " + amountEnemySpawned);

        for (int i = 0; i < amountToSpawn; i++) {
            // For each npc to place, select a random starting point.
            string spawnpoint = "Spawnpoint" + Random.Range(1, 5);

            // Place the normal NPCs first.
            if (i < amountNormalSpawned) {
                // Depending on the selected starting point, randomize either the X or the Z coordinate, while making sure that the randomized property falls within the range of the other spawnpoints.
                // This causes them to spawn in a nice rectangle (or however the spawnpoints are set up)
                if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                    npcs.Add(Instantiate(npc, new Vector3(
                        Random.Range(GameObject.Find("Spawnpoint4").transform.position.x, GameObject.Find("Spawnpoint2").transform.position.x),
                        1,
                        GameObject.Find(spawnpoint).transform.position.z),
                        Quaternion.identity, parent));
                //npcs[i].
                else if (spawnpoint == "Spawnpoint2" || spawnpoint == "Spawnpoint4")
                    npcs.Add(Instantiate(npc, new Vector3(
                        GameObject.Find(spawnpoint).transform.position.x,
                        1,
                        Random.Range(GameObject.Find("Spawnpoint1").transform.position.z, GameObject.Find("Spawnpoint3").transform.position.z)),
                        Quaternion.identity, parent));

            // After the normal NPCs spawn the idle NPCs in the same way
            } else if (i >= amountNormalSpawned && i < (amountNormalSpawned+amountIdleSpawned)) { 
                npcs.Add(Instantiate(npc, new Vector3(
                    GameObject.Find("IdleSpawnpoint"+(i-amountNormalSpawned+1)).transform.position.x, 
                    1, 
                    GameObject.Find("IdleSpawnpoint"+(i-amountNormalSpawned+1)).transform.position.z), 
                    Quaternion.identity, parent));
                //SampleAgentScript test = npcs[i].GetComponent<SampleAgentScript>();
                //test.isIdle = true;
                Destroy(npcs[i].GetComponent<NavMeshAgent>());
                Destroy(npcs[i].GetComponent<SampleAgentScript>());

            // After the idle NPCs, spawn the enemies in the same way.
            } else if (i >= (amountNormalSpawned + amountIdleSpawned) && i < amountToSpawn) {
                if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                    npcs.Add(Instantiate(enemy,
                        new Vector3(
                        Random.Range(GameObject.Find("Spawnpoint4").transform.position.x, GameObject.Find("Spawnpoint2").transform.position.x),
                        1,
                        GameObject.Find(spawnpoint).transform.position.z),
                        Quaternion.identity, parent));
                else if (spawnpoint == "Spawnpoint2" || spawnpoint == "Spawnpoint4")
                    npcs.Add(Instantiate(enemy, new Vector3(
                        GameObject.Find(spawnpoint).transform.position.x,
                        1,
                        Random.Range(GameObject.Find("Spawnpoint1").transform.position.z, GameObject.Find("Spawnpoint3").transform.position.z)),
                        Quaternion.identity, parent));
            }
        }
        print("npcs.count: " + npcs.Count);
    }
}