using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class TargetControl : MonoBehaviour {
    private KeyCode keyInput_targetWalksToPlayer = KeyCode.Space;
    private KeyCode keyInput_targetRuns = KeyCode.LeftShift;
    private KeyCode keyInput_targetDrawsKnife = KeyCode.LeftControl;
    private KeyCode keyInput_targetDrawsGun = KeyCode.RightControl;
    private KeyCode keyInput_targetsurrender = KeyCode.LeftAlt;
    private KeyCode keyInput_targetTurnsToCivilian = KeyCode.C;
    private KeyCode keyInput_targetShootsCivilianHit = KeyCode.H;
    private KeyCode keyInput_targetShootsCivilianMis = KeyCode.M;

    private bool knifeDrawn = false;

    private bool gunDrawn = false;

    private bool surrendered = false;
    
    private ShootCivilian shootCivilian;
    private MoveTarget moveTarget;

    /*
    public AudioSource walkAudio;
    public AudioSource knifeAudio;
    public AudioSource shootAudio;

    public KnifeAnimation knifeAnimations;
    public TargetAnimations targetAnimations;
    public GunAnimations gunAnimations;

    public List<AudioClip> drawKnifeAudioClips = new List<AudioClip>();
    public List<AudioClip> walkAudioClips = new List<AudioClip>();
    public List<AudioClip> shootAudioClips = new List<AudioClip>();
    */

    private List<Transform> civilianList = new List<Transform>();

    public Transform civilians;
    public Transform gunHole;

    //public Transform knife;

    //public Transform target;
    //public float maxMovementSpeed;
    //public float runFactor;
    //public float acceleration;

    //public float targetAccuracy;
    public float maxDistanceToCivilian;

    public float maxDistance;
    public float stabDistance;

    // Use this for initialization
    void Start() {
        //shootCivilian = new ShootCivilian(this, gunAnimations);
        shootCivilian = new ShootCivilian(this);
        moveTarget = new MoveTarget(this);

        //walkAudio = GetComponent<AudioSource>();

        // This makes sure that the target always has a max movement speed incase the user sets it to low
        //if (maxMovementSpeed <= 0) {
        //    maxMovementSpeed = 1.5f;
        //}

        // Gets all the civilians and puts them in a list that's easier to handle
        //foreach (Transform child in civilians.transform) {
        //    if (child.gameObject.tag.Equals("Civilian")) {
        //        shootCivilian.addCivilian(child);
        //    }
        //}
    }

    public void AnnesFillList(List<Transform> list) {
        
        this.civilianList = list;
        Debug.Log(civilianList.Count);
    }
    
    public void fillCivilianList(List<Transform> list) {
        foreach (Transform child in list) {
            if (child.gameObject.tag.Equals("Civilian")) {
                shootCivilian.addCivilian(child);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(keyInput_targetWalksToPlayer)) moveTarget.walkToTarget = !moveTarget.walkToTarget; // If you press space, it starts or stops walking to you
        if (Input.GetKeyDown(keyInput_targetRuns)) moveTarget.runEnabled = !moveTarget.runEnabled; // If you press the left shift, the target will run instead of walk
        if (Input.GetKeyDown(keyInput_targetDrawsKnife) && !Input.GetKeyDown(KeyCode.RightAlt)) { // If you press the left control, he draws the knife
            //Debug.Log("Drawing/Sheating knife");
            if (!surrendered && !gunDrawn) {    // Make sure he hasn't drawn his gun or has surrenderd
                //if (!knifeAnimations.AnimationIsPlaying("draw")) { // The target cannot be already drawing his knife
                    if (!knifeDrawn) {
                        knifeDrawn = true;
                        //DrawKnife();
                    } else if (knifeDrawn) {
                        knifeDrawn = false;
                        //SheatheKnife();
                    }
                //}
            }
        }
        if (Input.GetKeyDown(keyInput_targetDrawsGun) && !Input.GetKeyDown(KeyCode.RightAlt)) {
            if (!surrendered && !knifeDrawn) {
                //if (!gunAnimations.animationIsPlaying("draw")) {
                    if (!gunDrawn) {
                        gunDrawn = true;
                        //DrawGun();
                    } else if (gunDrawn) {
                        gunDrawn = false;
                        //SheatheGun();
                    }
                //}
            }
        }
        if (Input.GetKeyDown(keyInput_targetsurrender)) {
            if (!knifeDrawn) {
                if (!surrendered) {
                    surrendered = true;
                    //targetAnimations.surrender();
                } else {
                    surrendered = false;
                    //targetAnimations.aggresive();
                }
            }
        }
        if (Input.GetKeyDown(keyInput_targetTurnsToCivilian)) {
            //if (gunDrawn) {
            shootCivilian.turnToCivilian = true;
            shootCivilian.civilianToShoot = null;
            //}
        }
        if (Input.GetKeyDown(keyInput_targetShootsCivilianHit)) {
            if (!knifeDrawn && !surrendered) {
                shootCivilian.shoot = true;
                shootCivilian.hitCivilian = true;
            }
        }
        if (Input.GetKeyDown(keyInput_targetShootsCivilianMis)) {
            if (!knifeDrawn && !surrendered) {
                shootCivilian.shoot = true;
                shootCivilian.hitCivilian = false;
            }
        }

        //if (knifeDrawn) {
        //    if (knifeAnimations.GetAnimationTime("draw") >= 0.5 && knifeAnimations.GetAnimationTime("draw") <= 0.52) {
        //        knifeAudio.clip = drawKnifeAudioClips[UnityEngine.Random.Range(0, drawKnifeAudioClips.Count)];
        //        knifeAudio.Play();
        //    }
        //}
    }

    void FixedUpdate() {
        //if (moveTarget.walkToTarget || moveTarget.currentAcceleration > 0) moveTarget.WalkToTarget(target, transform);

        if (shootCivilian.turnToCivilian) shootCivilian.turnTargetToCivilian(transform);

        //if (shootCivilian.shoot) shootCivilian.shootAtCivilian(shootCivilian.hitCivilian, ref gunDrawn, gunHole);

        //if (knifeDrawn && !knifeAnimations.AnimationIsPlaying("draw")) {
        //    if (Vector3.Distance(target.transform.position, transform.position) <= stabDistance) Stab();
        //}
    }

    // This function makes the target shoot at the civilian
    

    

    // This rotates a transform with a range of -inaccuration to inaccuration + 1
    private void Inaccuracy(ref Transform transform, float inaccuration) {
        Vector3 rotation = new Vector3(UnityEngine.Random.Range(inaccuration * -1, inaccuration + 1), UnityEngine.Random.Range(inaccuration * -1, inaccuration + 1), UnityEngine.Random.Range(inaccuration * -1, inaccuration + 1));
        transform.Rotate(rotation);
    }

    // This sheaths the knife, playing the animation in reverse and playing the audio clip
    //private void SheatheKnife() {
    //    knifeAudio.clip = drawKnifeAudioClips[UnityEngine.Random.Range(0, drawKnifeAudioClips.Count)];
    //    knifeAudio.Play();
    //    knifeAnimations.SheatheKnife();
    //}

    //// This draws the knife
    //public void DrawKnife() {
    //    knifeAnimations.drawKnife();
    //}

    //// This sheathes the gun
    //private void SheatheGun() {
    //    gunAnimations.sheathGun();
    //}

    //// This draws the gun
    //private void DrawGun() {
    //    gunAnimations.drawGun();
    //}

    //// This stabs you
    //private void Stab() {
    //    knifeAnimations.Stab();
    //}

    //// This slashes you
    //private void Slash() {
    //    knifeAnimations.Slash();
    //}

    

    // This function rotates the target towards a specific point.
    public void rotateToTarget(Transform target, Vector3 selfPosition, ref Quaternion selfRotation, float slerp) {
        if (target != null) {
            Vector3 lookPosition = target.position - selfPosition;
            lookPosition.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPosition);
            rotation *= Quaternion.Euler(0, 90, 0);
            selfRotation = Quaternion.Slerp(selfRotation, rotation, Time.deltaTime * slerp);
        }
    }
}
