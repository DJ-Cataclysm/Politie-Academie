using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimations : MonoBehaviour {
    public void drawGun() {
        GetComponent<Animation>()["draw"].speed = 1;
        GetComponent<Animation>()["draw"].time = 0.0f;
        GetComponent<Animation>().Play("draw");
    }

    public void sheathGun() {
        GetComponent<Animation>()["draw"].speed = -1;
        GetComponent<Animation>()["draw"].time = GetComponent<Animation>()["draw"].length;
        GetComponent<Animation>().Play("draw");
    }

    public bool animationIsPlaying(string name) {
        return GetComponent<Animation>().IsPlaying(name);
    }

    public float GetAnimationTime(string name) {
        return GetComponent<Animation>()[name].time;
    }
}
