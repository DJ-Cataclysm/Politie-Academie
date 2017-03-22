using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {

    public GameObject obj1;
    public GameObject obj2;

    public abstract void Execute();
}
