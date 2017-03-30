using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmark : Mark {

    protected override void OnDestroy() {
        if (landmarks != null)
            landmarks.Remove(this);
        print("Landmark destroyed!");
    }
}
