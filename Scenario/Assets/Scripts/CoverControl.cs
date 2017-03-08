using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverControl : MonoBehaviour {

    private List<Transform> covers = new List<Transform>();

    public int coversActive {
        set {
            if(value <= maxCoversActive) enableCovers(value);
        }
        get {
            int count = 0;
            foreach(Transform t in covers) {
                count += t.gameObject.activeSelf ? 1 : 0;
            }
            return count;
        }
    }

    public int maxCoversActive { get { return covers.Count; } }

    // Use this for initialization
    void Start() {
        foreach(Transform child in transform) {
            covers.Add(child);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            coversActive = 1;
        }else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            coversActive = 2;
        }else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            coversActive = 3;
        }else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            coversActive = 4;
        }else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            coversActive = 5;
        }
    }

    private void enableCovers(int coversToEnable) {
        disableCovers();

        while(coversActive < coversToEnable) {
            int index = Random.Range(0, covers.Count);
            covers[index].gameObject.SetActive(true);
        }
    }

    private void disableCovers() {
        foreach (Transform t in covers) {
            t.gameObject.SetActive(false);
        }
    }
}
