using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetControl : MonoBehaviour {
    private bool walkToTarget = false; // Whether or not the target moves towards you
    private bool runEnabled = false;
    private float currentAcceleration = 0;

    private bool knifeDrawn = false;

    private bool gunDrawn = false;

    private bool surrendered = false;

    private bool shootCivilian = false;

    private bool turnToCivilian = false;
    private Transform civilianToShoot;

    private List<Transform> civilianList = new List<Transform>();

    public AudioSource walkAudio;  // The walk audio
    public AudioSource knifeAudio;

    public KnifeAnimation knifeAnimations;
    public TargetAnimations targetAnimations;
    public GunAnimations gunAnimations;

    public List<AudioClip> drawKnifeAudioClips = new List<AudioClip>();
    public List<AudioClip> walkAudioClips = new List<AudioClip>();

    public Transform civilians;
    public Transform gunHole;

    public Transform knife;

    public Transform target;    // The object the target walks towards
    //public float rotationSlerp;     // How fast the target rotates
    public float maxMovementSpeed;  // How fast the target walks in seconds
    public float runFactor;
    public float acceleration;

    public float targetAccuracy;
    public float maxDistanceToCivilian;

    public float maxDistance;       // How close the target can get to you before stopping
    public float stabDistance;

    // Gets the difference between 2 floats
    Func<float, float, float> getDelta = (a, b) => a - b;

    // Use this for initialization
    void Start() {
        // Gets the audio source component
        walkAudio = GetComponent<AudioSource>();

        // If the movementspeed of the target is equal or less than zero, set it to 1.5
        if (maxMovementSpeed <= 0) {
            maxMovementSpeed = 1.5f;
        }

        foreach (Transform child in civilians.transform) {
            civilianList.Add(child);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) walkToTarget = !walkToTarget; // If you press space, it starts or stops walking to you
        if (Input.GetKeyDown(KeyCode.LeftShift)) runEnabled = !runEnabled; // If you press the left shift, the target will run instead of walk
        if (Input.GetKeyDown(KeyCode.RightControl) && !Input.GetKeyDown(KeyCode.RightAlt)) {
            //Debug.Log("Drawing/Sheating knife");
            if (!surrendered && !gunDrawn) {
                if (!knifeAnimations.AnimationIsPlaying("draw")) {
                    if (!knifeDrawn) {
                        knifeDrawn = true;
                        DrawKnife();
                    } else if (knifeDrawn) {
                        knifeDrawn = false;
                        SheatheKnife();
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && !Input.GetKeyDown(KeyCode.RightAlt)) {
            if (!surrendered && !knifeDrawn) {
                if (!gunAnimations.animationIsPlaying("draw")) {
                    if (!gunDrawn) {
                        gunDrawn = true;
                        DrawGun();
                    }else if (gunDrawn) {
                        gunDrawn = false;
                        SheatheGun();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            if (!knifeDrawn) {
                if (!surrendered) {
                    surrendered = true;
                    targetAnimations.surrender();
                } else {
                    surrendered = false;
                    targetAnimations.aggresive();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightAlt)) {
            if (gunDrawn) {
                turnToCivilian = true;
                shootCivilian = true;
            }
        }

        if (knifeDrawn) {
            if (knifeAnimations.GetAnimationTime("draw") >= 0.5 && knifeAnimations.GetAnimationTime("draw") <= 0.52) {
                knifeAudio.clip = drawKnifeAudioClips[UnityEngine.Random.Range(0, drawKnifeAudioClips.Count)];
                knifeAudio.Play();
            }
        }
    }

    void FixedUpdate() {
        // If space has been pressed, walk and rotate
        //Debug.Log(walkToTarget.ToString() + " - " + currentAcceleration);
        if (walkToTarget || currentAcceleration > 0) WalkToTarget();

        if (shootCivilian || turnToCivilian) ShootCivilian();

        if (knifeDrawn && !knifeAnimations.AnimationIsPlaying("draw")) {
            if (Vector3.Distance(target.transform.position, transform.position) <= stabDistance) Stab();
        }
    }

    private void ShootCivilian() {
        while (civilianToShoot == null) {
            Transform temp = civilianList[UnityEngine.Random.Range(0, civilianList.Count)];
            if (Vector3.Distance(transform.position, temp.position) < maxDistanceToCivilian && temp.gameObject.activeSelf) civilianToShoot = temp;
        }

        if (turnToCivilian) {
            Quaternion temp = transform.rotation;
            rotateToTarget(civilianToShoot.transform, transform.position, ref temp, 5f);
            transform.rotation = temp;

            Vector3 targetToCivilian = (civilianToShoot.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(targetToCivilian, transform.forward);
            if (dot < 0.001 && dot > -0.001) {
                turnToCivilian = false;
            }
        }

        if (!turnToCivilian && shootCivilian) {
            Quaternion gunHoleRotation = gunHole.transform.rotation;
            Inaccuracy(ref gunHole, targetAccuracy);
            Vector3 forward = gunHole.transform.TransformDirection(Vector3.forward);
            RaycastHit targetHit;
            //Debug.DrawRay(gunHole.transform.position, forward, Color.red, 10);
            if(Physics.Raycast(gunHole.transform.position, forward, out targetHit)) {
                if (targetHit.transform.gameObject.tag.Equals("Civilian")) {
                    targetHit.transform.gameObject.SetActive(false);
                }
            }
            shootCivilian = false;
            civilianToShoot = null;
            gunHole.transform.rotation = gunHoleRotation;
        }
    }

    private void Inaccuracy(ref Transform transform, float inaccuration) {
        Vector3 rotation = new Vector3(UnityEngine.Random.Range(inaccuration * -1, inaccuration + 1), UnityEngine.Random.Range(inaccuration * -1, inaccuration + 1), UnityEngine.Random.Range(inaccuration * -1, inaccuration + 1));
        transform.Rotate(rotation);
    }

    private void SheatheKnife() {
        knifeAudio.clip = drawKnifeAudioClips[UnityEngine.Random.Range(0, drawKnifeAudioClips.Count)];
        knifeAudio.Play();
        knifeAnimations.SheatheKnife();
    }

    private void DrawKnife() {
        knifeAnimations.drawKnife();
    }

    private void SheatheGun() {
        gunAnimations.sheathGun();
    }

    private void DrawGun() {
        gunAnimations.drawGun();
    }

    private void Stab() {
        knifeAnimations.Stab();
    }

    private void Slash() {
        knifeAnimations.Slash();
    }

    private void WalkToTarget() {
        // Rotates the target
        Quaternion temp = transform.rotation;
        rotateToTarget(target, transform.position, ref temp, 5f);
        transform.rotation = temp;

        // Gets the distance between you and the target
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        //Debug.Log(distanceToTarget + " - " + maxDistance);

        // If the target is outside the maxDistance range, move closer
        if (distanceToTarget > maxDistance) {
            // If the walk audio is not playing, play it
            if (!walkAudio.isPlaying) {
                walkAudio.clip = walkAudioClips[UnityEngine.Random.Range(0, walkAudioClips.Count)];
                walkAudio.Play();
            }

            // A float that holds how many seconds the target takes to get to you
            float factor = distanceToTarget / (runEnabled ? maxMovementSpeed * runFactor : maxMovementSpeed);

            // The difference in X and Z between you and the target
            float deltaX = getDelta(target.position.x, transform.position.x);
            float deltaZ = getDelta(target.position.z, transform.position.z);

            // Gets how much units the target moves on the X-axis this second.
            float distanceThisSecondX = deltaX / factor;
            //gets how much units the target moves on the Y-axis this frame.
            float distanceThisFrameX = distanceThisSecondX * Time.deltaTime;

            // Same as above but then for the Z-axis
            float distanceThisSecondZ = deltaZ / factor;
            float distanceThisFrameZ = distanceThisSecondZ * Time.deltaTime;

            if (walkToTarget) {
                if (currentAcceleration < 1) {
                    currentAcceleration += acceleration;
                    if (currentAcceleration > 1) currentAcceleration = 1;
                }
            }else {
                if(currentAcceleration > 0) {
                    currentAcceleration -= acceleration;
                    if(currentAcceleration < 0) {
                        currentAcceleration = 0;
                    }
                }
            }

            // moves the target
            transform.position += (new Vector3(distanceThisFrameX, 0, distanceThisFrameZ)) * currentAcceleration;
        }
    }

    // This function rotates the target towards a specific point.
    private void rotateToTarget(Transform target, Vector3 selfPosition, ref Quaternion selfRotation, float slerp) {
        if (target != null) {
            Vector3 lookPosition = target.position - selfPosition;
            lookPosition.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPosition);
            rotation *= Quaternion.Euler(0, 90, 0);
            selfRotation = Quaternion.Slerp(selfRotation, rotation, Time.deltaTime * slerp);
        }
    }
}
