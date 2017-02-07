using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCockAnim : MonoBehaviour {

    public void GunCock() {
        GetComponent<Animation>().Play("key");
    }

    public void GunEmpty() {
        GetComponent<Animation>().Play("empty");
    }

    public void GunReload() {
        GetComponent<Animation>().Play("reload");
    }
}
