using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour {

    // Variables relating to the current target. These affect the Target Cam, and are determined by their index in the npcs List item.
    private Transform currentTarget;
    private int currentTargetIndex = 0;

    // Variables relating to the different types of NPCs, these will be used to spawn them.
    public List<Transform> npcs = new List<Transform>();
    public List<Transform> npcsToTransfer = new List<Transform>();
    public Transform npc;
    public Transform enemy;
    public Transform parent;

    // Variables relating to the amount of NPCs to spawn. These can be altered from the menu.
    private float amountToSpawn;
    public float amountNormalSpawned = 40;
    public float amountEnemySpawned = 0;
    public float amountIdleSpawned = 0;

    public TargetControl targetControl;

    void Start() {
        amountToSpawn = amountNormalSpawned + amountEnemySpawned + amountIdleSpawned;
        print("Amount to spawn is: " + amountToSpawn + ". Normal is: " + amountNormalSpawned + ". Idle is: " + amountIdleSpawned + ". Enemy is: " + amountEnemySpawned);

        for (int i = 0; i < amountToSpawn; i++) {
            // For each npc to place, select a random starting point.
            string spawnpoint = "Spawnpoint" + Random.Range(1, 5);

            // Place the enemies first.
            if (i < amountEnemySpawned) {
                // Depending on the selected starting point, randomize either the X or the Z coordinate, while making sure that the randomized property falls within the range of the other spawnpoints.
                // This causes them to spawn in a nice rectangle (or however the spawnpoints are set up)
                if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                    npcs.Add(Instantiate(enemy, new Vector3(
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
                //npcs[i].GetComponent<TargetControl>().ta;
                // After the enemies, spawn the idle NPCs in the same way
            } else if (i >= amountEnemySpawned && i < (amountEnemySpawned + amountIdleSpawned)) {
                npcs.Add(Instantiate(npc, new Vector3(
                    GameObject.Find("IdleSpawnpoint" + (i - amountNormalSpawned + 1)).transform.position.x,
                    1,
                    GameObject.Find("IdleSpawnpoint" + (i - amountNormalSpawned + 1)).transform.position.z),
                    Quaternion.identity, parent));
                //SampleAgentScript test = npcs[i].GetComponent<SampleAgentScript>();
                //test.isIdle = true;
                Destroy(npcs[i].GetComponent<NavMeshAgent>());
                Destroy(npcs[i].GetComponent<SampleAgentScript>());

                // After the idle NPCs, spawn the normal NPCs in the same way.
            } else if (i >= (amountEnemySpawned + amountIdleSpawned) && i < amountToSpawn) {
                if (spawnpoint == "Spawnpoint1" || spawnpoint == "Spawnpoint3")
                    npcs.Add(Instantiate(npc,
                        new Vector3(
                        Random.Range(GameObject.Find("Spawnpoint4").transform.position.x, GameObject.Find("Spawnpoint2").transform.position.x),
                        1,
                        GameObject.Find(spawnpoint).transform.position.z),
                        Quaternion.identity, parent));
                else if (spawnpoint == "Spawnpoint2" || spawnpoint == "Spawnpoint4")
                    npcs.Add(Instantiate(npc, new Vector3(
                        GameObject.Find(spawnpoint).transform.position.x,
                        1,
                        Random.Range(GameObject.Find("Spawnpoint1").transform.position.z, GameObject.Find("Spawnpoint3").transform.position.z)),
                        Quaternion.identity, parent));
            }
        }

        for (int i = (int)amountEnemySpawned; i < npcs.Count; i++) npcsToTransfer.Add(npcs[i - 1]);

        for (int i = 0; i < amountEnemySpawned; i++) {
            npcs[i].GetComponent<TargetControl>().AnnesFillList(npcsToTransfer);
        }

        print("npcs.count: " + npcs.Count);
    }

    private void Update() {
        // If the keys "1", "2", "3", or "4" is pressed, that key is sent to the current target's script. Depending on the target, they (could) act differently.
        //if(Input.anyKeyDown)
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
            currentTarget.GetComponent<TriggerAction>().FireAction(Input.inputString, npcsToTransfer);

        // If LeftArrow or RightArrow are pressed, shut off the current target's camera, advance to the next target, and switch on its camera.
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            currentTarget.GetChild(0).transform.gameObject.SetActive(false);
            currentTargetIndex++;
            // A simple "if" to prevent the currentTargetIndex from going out of bounds
            if (currentTargetIndex > (amountEnemySpawned - 1))
                currentTargetIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            currentTarget.GetChild(0).transform.gameObject.SetActive(false);
            currentTargetIndex--;
            if (currentTargetIndex < 0)
                currentTargetIndex = (int)(amountEnemySpawned - 1);
        }

        // Set the currentTarget, and turn its camera on.
        while (currentTarget.transform.gameObject.activeInHierarchy == false) {
            currentTargetIndex++;
        }
        currentTarget = npcs[currentTargetIndex];
        currentTarget.GetChild(0).transform.gameObject.SetActive(true);
    }
}