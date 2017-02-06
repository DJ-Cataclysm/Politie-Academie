#pragma strict

var sound : AudioClip;
 
 function Update () {
 
 if (Input.GetMouseButtonDown(0)) {
 
 GetComponent.<AudioSource>().PlayOneShot (sound);
 
 
 }
 }