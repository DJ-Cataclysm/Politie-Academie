using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReloader : MonoBehaviour {

    List<Transform> targets = new List<Transform>();

    public int maxTargetsActive;

    public Transform targetPos;
    public Transform targetHit;
    public AudioClip targetSpawn;

    private bool activatingTargets = false;

    // Use this for initialization
    void Start() {
        foreach (Transform child in transform) {
            targets.Add(child);
        }

        if (maxTargetsActive <= 0 || maxTargetsActive > targets.Count / 2) {
            maxTargetsActive = 2;
        }
        
        while (getActiveTargets() < maxTargetsActive) {
            activateTargets();
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        if (getActiveTargets() < maxTargetsActive && !activatingTargets) {
            while (getActiveTargets() < maxTargetsActive) {
                activateTargets();
            }
            targetHit = null;
        }
    }

    public int getActiveTargets()
    {
        int count = 0;
        foreach(Transform target in targets)
        {
            count += target.gameObject.activeSelf ? 1 : 0;
        }
        return count;
    }

    public void activateTargets() {
        activatingTargets = true;

        int index = Random.Range(0, targets.Count);

        if (targetHit != null) {
            if (!targetHit.Equals(targets[index])) {
                targets[index].gameObject.SetActive(true);
            }
        } else {
            targets[index].gameObject.SetActive(true);
            // play sound
            //targets[index].GetComponent<AudioSource>().Play();
        }

        activatingTargets = false;
    }
}



//void Start()
//{

//    StartCoroutine(AdjustVolume());

//}

//IEnumerator AdjustVolume()
//{

//    while (true)
//    {

//        if (audio.isPlaying)
//        { // do this only if some audio is being played in this gameObject's AudioSource

//            float distanceToTarget = Vector3.Distance(transform.position, target.position); // Assuming that the target is the player or the audio listener

//            if (distanceToTarget < 1) { distanceToTarget = 1; }

//            audio.volume = 1 / distanceToTarget; // this works as a linear function, while the 3D sound works like a logarithmic function, so the effect will be a little different (correct me if I'm wrong)

//            yield return new WaitForSeconds(1); // this will adjust the volume based on distance every 1 second (Obviously, You can reduce this to a lower value if you want more updates per second)

//        }
//    }

//}