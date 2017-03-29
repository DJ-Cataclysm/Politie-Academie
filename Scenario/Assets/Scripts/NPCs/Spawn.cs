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
    }

    // This function decides where and how the standard Friendly NPCs spawn (Type: FriendlyNPC.cs)
    private void SpawnFriendlies() {
        // For each FriendlyNPC to spawn, decide a random direction (normalized vector) and multiply that by a random amount to determine distance.
        // Finally, offset it around the player so the NPCs don't spawn in the player's face.
        for (int i = 0; i < amountFriendliesSpawned; i++) {
            Vector3 randomDir = new Vector3(RNG.NextFloat(-1, 1), 0, RNG.NextFloat(-1, 1)).normalized;
                Instantiate(npc,
                    (randomDir * RNG.NextFloat(10, 30)) + Vector3.up + GameObject.Find("[CameraRig]").transform.position,
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
                Vector3 randomDir = new Vector3(RNG.NextFloat(-1, 1), 0, RNG.NextFloat(-1, 1)).normalized;
                Instantiate(enemy,
                    (randomDir * RNG.NextFloat(10, 30)) + Vector3.up + GameObject.Find("[CameraRig]").transform.position,
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