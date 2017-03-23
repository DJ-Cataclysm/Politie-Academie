using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour {

    public float radius = 2000F;
    public float power = 500.0F;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("EXPLOOOOOOOOOOOOOOOOSION");
            Vector3 explosionPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 0.0F);
            }
        }
        
    }
}
