using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCivilian : MonoBehaviour {
    public void shootAtCivilian() {
        // Pretend to Pew Pew Pew
        GetComponent<AudioSource>().Play();
        Debug.Log("He Shoots, and... he misses. What a dissapointment");
    }
}
