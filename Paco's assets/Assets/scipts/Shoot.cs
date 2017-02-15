using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject source;
    public GameObject projectile;
    public float bulletspeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	GetInput();
	}

    void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            projectile.GetComponent<Bullet>().speed=bulletspeed;
            Instantiate(projectile,source.transform.position,source.transform.rotation);
        }
    }
}
