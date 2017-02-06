using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider))]
public class Controller3D : MonoBehaviour {

    const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    public GameObject raycastObject;
    RaycastHit objectHit;

    BoxCollider collider;
    RaycastOrigins raycastOrigins;

	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider>();
        CalculateRaySpacing();
	}

    void Update() {
        for (int i = 0; i < verticalRayCount; i++) {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector3.right * verticalRaySpacing * i, Vector3.up * -2, Color.red);
        }
        if (Input.GetMouseButtonDown(0)) {

            CheckForHit();
        }
    }

    public void Shoot() {
        
        //Debug.DrawRay(raycastOrigins.center, Vector3.forward, Color.green);
        //if (Physics.Raycast(raycastOrigins.center, Vector3.forward)) {
        //    print("Hit something!");
        //}
    }

    void CheckForHit() {
        UpdateRaycastOrigins();
        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit, 50)) {
            print("Hit something!");
        }
    }

    void UpdateRaycastOrigins() {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
        raycastOrigins.bottomRight = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
        raycastOrigins.topLeft = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
        raycastOrigins.topRight = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);

        raycastOrigins.center = new Vector3(bounds.center.x, bounds.center.y, bounds.center.z);
    }

    void CalculateRaySpacing() {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins {
        public Vector3 topLeft, topRight;
        public Vector3 bottomLeft, bottomRight;
        public Vector3 center;
    }
	
}
