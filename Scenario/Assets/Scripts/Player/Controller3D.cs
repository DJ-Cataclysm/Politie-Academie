﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller3D : MonoBehaviour {

    //public TargetReloader targets;

    //public Text accuracy;
    //public Text points;

    int shotsFired;
    int shotsHit;

    [SerializeField] private GameObject raycastObject;
    RaycastHit objectHit;

    [SerializeField] private AudioClip gunShoot;
    [SerializeField] private AudioClip reload;
    [SerializeField] private AudioClip click;

    [SerializeField] private GunCockAnim anim;
    [SerializeField] private ParticleSystem p;

    int shotCount;
    [SerializeField] private int clipSize;

    void Start() {
        this.gameObject.AddComponent<AudioSource>();
        this.shotCount = 0;
    }

    //private void FixedUpdate() {
        //int accurate = shotsHit * 100 / shotsFired;
        //accuracy.text = "Accuracy: " + accurate + "%. Schoten: " + shotsFired + ", doelen geraakt: " + shotsHit;
    //}

    public void FireGun() {
        if (GetComponent<Animation>().IsPlaying("reload") == false) {
            if (shotCount < clipSize) {
                this.shotCount++;
                shotsFired++;
                CheckForHit();

                // Play animation
                this.GetComponent<AudioSource>().clip = gunShoot;
                this.GetComponent<AudioSource>().Play();
                anim.GunCock();
                p.Play();
                if (this.shotCount == clipSize)
                    anim.GunEmpty();
            }
            else if (shotCount >= clipSize) {
                this.GetComponent<AudioSource>().clip = click;
                this.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void ReloadGun() {
        //if (this.shotCount == clipSize) {
            this.shotCount = 0;
            this.GetComponent<AudioSource>().clip = reload;
            this.GetComponent<AudioSource>().Play();
            anim.GunReload();
        //}
        //else print("Pistool is niet leeg");
    }

    public void CheckForHit() {
        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit)) {
            print(objectHit.transform.gameObject.name);
                objectHit.transform.gameObject.SetActive(false);
                //targets.targetHit = objectHit.transform;
                shotsHit++;
            //Destroy(objectHit.transform.gameObject);
        }
    }
}
