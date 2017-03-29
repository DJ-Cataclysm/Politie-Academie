using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLandmark : Mark {

    protected override void OnDestroy() {
        if (eLandmarks != null)
            eLandmarks.Remove(this);
        print("EnemyLandmark destroyed!");
    }
}
