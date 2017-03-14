using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class ShootCivilian {
        private TargetControl targetControl;

        private GunAnimations gunAnimations;


        public bool shoot = false;
        public bool hitCivilian = false;

        public bool turnToCivilian = false;
        public Transform civilianToShoot;

        public readonly List<Transform> civilianList = new List<Transform>();


        public ShootCivilian(TargetControl targetControl) {
            this.targetControl = targetControl;
            //this.gunAnimations = gunAnimations;
        }


        public ShootCivilian(TargetControl targetControl, GunAnimations gunAnimations) {
            this.targetControl = targetControl;
            this.gunAnimations = gunAnimations;
        }


        public int activeCivilians {
            get {
                int count = 0;
                foreach (Transform child in civilianList) {
                    if (child.gameObject.activeSelf) count++;
                }
                return count;
            }
        }


        public void addCivilian(Transform civilian) {
            civilianList.Add(civilian);
        }

        public void turnTargetToCivilian(Transform transform) {
            int count = 0;

            // This while-loop gets a random civilian, but it makes sure that the civilian is in range and active. Also, after 5 tries, it stops
            while (civilianToShoot == null && activeCivilians > 0) {
                Transform temp = civilianList[UnityEngine.Random.Range(0, civilianList.Count)];
                if (Vector3.Distance(transform.position, temp.position) < targetControl.maxDistanceToCivilian && temp.gameObject.activeSelf) civilianToShoot = temp;
                count++;
                if (count >= 5) {
                    break;
                }
            }

            // This turns the target to the civilian.
            if (turnToCivilian && civilianToShoot != null) {
                Quaternion temp = transform.rotation;
                targetControl.rotateToTarget(civilianToShoot.transform, transform.position, ref temp, 5f);
                transform.rotation = temp;

                Vector3 targetToCivilian = (civilianToShoot.transform.position - transform.position).normalized;
                float dot = Vector3.Dot(targetToCivilian, transform.forward);
                if (dot < 0.001 && dot > -0.001) {
                    turnToCivilian = false;
                }
            }
        }

        //public void shootAtCivilian(bool hit, ref bool gunDrawn, Transform gunHole) {
        //    if (!gunDrawn) {
        //        gunAnimations.drawGun();
        //        gunDrawn = true;
        //    } else if (!gunAnimations.animationIsPlaying("draw")) {
        //        shoot = false;

        //        //targetControl.shootAudio.clip = targetControl.shootAudioClips[UnityEngine.Random.Range(0, targetControl.shootAudioClips.Count)];
        //        //targetControl.shootAudio.Play();

        //        if (hit) {

        //            Vector3 forward = gunHole.transform.TransformDirection(Vector3.forward);
        //            RaycastHit targetHit;

        //            // Shoot the bullet, and if it hits, check if it is a civilian
        //            if (Physics.Raycast(gunHole.transform.position, forward, out targetHit)) {
        //                if (targetHit.transform.gameObject.tag.Equals("Civilian")) {
        //                    turnToCivilian = false;
        //                    civilianToShoot = null;
        //                    targetHit.transform.gameObject.SetActive(false);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
