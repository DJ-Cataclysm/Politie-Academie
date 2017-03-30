using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplosionForce : MonoBehaviour {

    public float radius;
    public float power = 500.0F;
    public AudioClip explosionSound;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            //this.gameObject.GetComponent<AudioSource>().PlayOneShot();
            Debug.Log("EXPLOOOOOOOOOOOOOOOOSION");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
            Vector3 explosionPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (!hit.GetComponent<Rigidbody>() && hit.tag == "Civilian")
                    hit.gameObject.AddComponent<Rigidbody>();

                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (hit.tag == "Civilian")
                {
                    Debug.Log("Why you hit me bro?");
                    hit.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    hit.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
                    hit.gameObject.GetComponent<NavMeshAgent>().updateRotation = false;
                    hit.gameObject.GetComponent<FriendlyNPC>().enabled = false;
                    hit.gameObject.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                    hit.gameObject.GetComponentInChildren<Animator>().SetBool("Walking2Death", true);
                    //hit.gameObject.GetComponent<BoxCollider>().size = new Vector3();
                }
                    

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, -2.0F);

            }
        }
        
    }
}
