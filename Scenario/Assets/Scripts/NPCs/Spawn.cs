using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    // Variables relating to the different types of NPCs, these will be used to spawn them.
    [SerializeField] private Transform npc;
    [SerializeField] private Transform enemy;

    // Variables relating to the amount of NPCs to spawn. These can be altered from the menu. The values here are just defaults.
    [SerializeField] private int amountFriendliesSpawned = 40;
    [SerializeField] private int amountHostilesSpawned = 1;
    [SerializeField] private int amountIdleSpawned = 0;


    // Temporary variables
    public int enemySpawn;
    [SerializeField] private bool randomSpawn;

    // Start() simply calls the three functions which spawn the NPCs. 
    void Start() {
        SpawnFriendlies();
        SpawnIdles();

        if (randomSpawn) {
            SpawnHostiles();
        } else {
            GameObject.FindObjectOfType<Inputhandler>().SpawnEvent.AddListener(SpawnHostiles);
        }

        //print(Mark.spawnmarks[0].transform.position + "  " + Mark.spawnmarks[1].transform.position + "  " + Mark.spawnmarks[2].transform.position + "  " + Mark.spawnmarks[3].transform.position);

    }

    // This function decides where and how the standard Friendly NPCs spawn (Type: FriendlyNPC.cs)
    private void SpawnFriendlies() {
        for (int i = 0; i < amountFriendliesSpawned; i++) {
            int random = Random.Range(0, Mark.spawnmarks.Count);
            Spawnmark spawnmark = Mark.spawnmarks[random];
            //if (random % 2 == 0)
            if (random == 0 || random == 3)
                Instantiate(npc,
                    new Vector3(
                    Random.Range(Mark.spawnmarks[2].transform.position.x, Mark.spawnmarks[1].transform.position.x),
                    1,
                    spawnmark.gameObject.transform.position.z),
                    Quaternion.identity, transform);
            //else if (random % 2 == 1)
            else if (random == 1 || random == 2)
                Instantiate(npc, new Vector3(
                    spawnmark.gameObject.transform.position.x,
                    1,
                    Random.Range(Mark.spawnmarks[3].transform.position.z, Mark.spawnmarks[0].transform.position.z)),
                    Quaternion.identity, transform);
        }
    }
    // This function spawns Idle NPCs. It's empty right now..
    private void SpawnIdles() {

    }

    // This function decides where and how the Hostile NPCs spawn. (Type: HostileNPC.cs)
    private void SpawnHostiles() {
        if (randomSpawn) {
            for (int i = 0; i < amountHostilesSpawned; i++) {
                int random = Random.Range(0, Mark.spawnmarks.Count);
                Spawnmark spawnmark = Mark.spawnmarks[random];
                //if (random % 2 == 0)
                if (random == 0 || random == 3)
                    Instantiate(enemy,
                        new Vector3(
                        Random.Range(Mark.spawnmarks[2].transform.position.x, Mark.spawnmarks[1].transform.position.x),
                        1,
                        spawnmark.gameObject.transform.position.z),
                        Quaternion.identity, transform);
                //else if (random % 2 == 1)
                else if (random == 1 || random == 2)
                    Instantiate(enemy, new Vector3(
                        spawnmark.gameObject.transform.position.x,
                        1,
                        Random.Range(Mark.spawnmarks[3].transform.position.z, Mark.spawnmarks[0].transform.position.z)),
                        Quaternion.identity, transform);
            }
        } else {
            for (float i = 0; i < amountHostilesSpawned; i++) {
                EnemySpawnmark eSpawnmark = Mark.eSpawnmarks[enemySpawn];
                Instantiate(enemy, new Vector3(
                    eSpawnmark.transform.position.x,
                    1,
                    eSpawnmark.transform.position.z),
                    Quaternion.identity, transform);
            }
        }
    }
}