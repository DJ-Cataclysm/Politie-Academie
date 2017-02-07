using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour {

    public TargetReloader targets;

    public GameObject raycastObject;
    RaycastHit objectHit;

    public AudioClip gunShoot;
    public AudioClip reload;
    public AudioClip click;

    public GunCockAnim anim;
    public ParticleSystem p;

    int shotCount;
    public int clipSize;

    void Start() {
        this.gameObject.AddComponent<AudioSource>();
        this.shotCount = 0;
    }

    void Update() {}

    public void FireGun() {
        if (shotCount < clipSize) {
            this.shotCount++;
            CheckForHit();

            // Play animation
            this.GetComponent<AudioSource>().clip = gunShoot;
            this.GetComponent<AudioSource>().Play();
            anim.GunCock();
            p.Play();
            print(shotCount);
            if (this.shotCount == clipSize) {
                anim.GunEmpty();
                print("Gun empty! shotCount is: " + (shotCount) + ". Press \"R\" to reload!");
            }
        }else if(shotCount >= clipSize) {
            this.GetComponent<AudioSource>().clip = click;
            this.GetComponent<AudioSource>().Play();
        }
    }

    public void ReloadGun() {
        if (this.shotCount == clipSize) {
            this.shotCount = 0;
            this.GetComponent<AudioSource>().clip = reload;
            this.GetComponent<AudioSource>().Play();
            //anim.GunReload();
            anim.GunCock();
            print("Gun reloaded!");
        } else {
            print("Pistool is niet leeg");
        }
    }

    public void CheckForHit() {
        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit)) {
            print("You hit: " + objectHit.transform.gameObject.name);
            //Destroy(objectHit.transform.gameObject);
        }
    }
}
