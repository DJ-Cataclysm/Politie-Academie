using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnmark : Mark {

    protected override void OnDestroy() {
        if (eSpawnmarks != null)
            eSpawnmarks.Remove(this);
        print("EnemySpawnmark destroyed!");
    }
}
