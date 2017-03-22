using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour {
    // Variables relating to the different types of NPCs, these will be used to spawn them.
    [SerializeField] private Transform npc;
    [SerializeField] private Transform enemy;

    // Variables relating to the amount of NPCs to spawn. These can be altered from the menu. The values here are just defaults.
    [SerializeField] private int amountNormalSpawned = 40;
    [SerializeField] private int amountHostilesSpawned = 1;
    [SerializeField] private int amountIdleSpawned = 0;   

    // Start() simply calls the three functions which spawn the NPCs. 
    void Start() {
        SpawnFriendlies(amountNormalSpawned);
        SpawnIdles(amountIdleSpawned);
        SpawnHostiles(amountHostilesSpawned);

        print("All: " + NPC.all.Count + "  Friendly: " + NPC.friendlies.Count + "  Hostile: " + NPC.hostiles.Count);
    }

    // This function decides where and how the standard Friendly NPCs spawn (Type: FriendlyNPC.cs)
    private void SpawnFriendlies(int amountToSpawn) {
        for (float i = 0; i < amountToSpawn; i++) {
            string spawnpoint = "Spawnpoint" + Random.Range(1, 5);
            if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                Instantiate(npc,
                    new Vector3(
                    Random.Range(GameObject.Find("Spawnpoint4").transform.position.x, GameObject.Find("Spawnpoint2").transform.position.x),
                    1,
                    GameObject.Find(spawnpoint).transform.position.z),
                    Quaternion.identity, transform);
            else if (spawnpoint == "Spawnpoint2" || spawnpoint == "Spawnpoint4")
                Instantiate(npc, new Vector3(
                    GameObject.Find(spawnpoint).transform.position.x,
                    1,
                    Random.Range(GameObject.Find("Spawnpoint1").transform.position.z, GameObject.Find("Spawnpoint3").transform.position.z)),
                    Quaternion.identity, transform);
        }
    }
    // This function spawns Idle NPCs. It's empty right now..
    private void SpawnIdles(int amountToSpawn) {

    }

    // This function decides where and how the Hostile NPCs spawn. (Type: HostileNPC.cs)
    private void SpawnHostiles(int amountToSpawn) {
        for (float i = 0; i < amountToSpawn; i++) {
            string spawnpoint = "Spawnpoint" + Random.Range(1, 5);
            if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                Instantiate(enemy, new Vector3(
                    Random.Range(GameObject.Find("Spawnpoint4").transform.position.x, GameObject.Find("Spawnpoint2").transform.position.x),
                    1,
                    GameObject.Find(spawnpoint).transform.position.z),
                    Quaternion.identity, transform);

            else if (spawnpoint == "Spawnpoint2" || spawnpoint == "Spawnpoint4")
                Instantiate(enemy, new Vector3(
                    GameObject.Find(spawnpoint).transform.position.x,
                    1,
                    Random.Range(GameObject.Find("Spawnpoint1").transform.position.z, GameObject.Find("Spawnpoint3").transform.position.z)),
                    Quaternion.identity, transform);
        }
    }
}