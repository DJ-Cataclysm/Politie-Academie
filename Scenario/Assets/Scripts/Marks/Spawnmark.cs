using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmark : Mark {

    private void Awake() {
        //print("My location is:" + this.transform.position);
    }

    protected override void OnDestroy() {
        if (spawnmarks != null)
            spawnmarks.Remove(this);
        print("Spawnmark destroyed");
    }
}
