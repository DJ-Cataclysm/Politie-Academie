using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour {
    public void Stab() {
        GetComponent<Animation>().Play("stab");
    }

    public void Slash() {
        GetComponent<Animation>().Play("slash");
    }

    public void drawKnife() {
        GetComponent<Animation>()["draw"].speed = 1;
        GetComponent<Animation>()["draw"].time = 0.0f;
        GetComponent<Animation>().Play("draw");
    }

    public void SheatheKnife() {
        GetComponent<Animation>()["draw"].speed = -1;
        GetComponent<Animation>()["draw"].time = GetComponent<Animation>()["draw"].length;
        GetComponent<Animation>().Play("draw");
    }

    public bool AnimationIsPlaying(string name) {
        return GetComponent<Animation>().IsPlaying(name);
    }

    public float GetAnimationTime(string name) {
        return GetComponent<Animation>()[name].time;
    }
}
