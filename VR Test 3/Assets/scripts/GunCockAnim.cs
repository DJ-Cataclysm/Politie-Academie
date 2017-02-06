using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCockAnim : MonoBehaviour {

    public void GunCock() {
        GetComponent<Animation>().Play();
        print("FIRE!");
    }
}
