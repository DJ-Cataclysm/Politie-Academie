using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverControl : MonoBehaviour {

    private List<Transform> covers = new List<Transform>();

    private List<bool> boolList = new List<bool>();

    public Text text;

    public int coversActive {
        set {
            if (value <= maxCoversActive) enableCovers(value);
        }
        get {
            int count = 0;
            foreach (Transform t in covers) count += t.gameObject.activeSelf ? 1 : 0;
            return count;
        }
    }

    public int maxCoversActive { get { return covers.Count; } }

    // Use this for initialization
    void Start() {
        foreach (Transform child in transform) {
            covers.Add(child);
            boolList.Add(new bool());
        }
        text.text = "";
        coversActive = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) coversActive = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) coversActive = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) coversActive = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) coversActive = 4;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) coversActive = 5;
        else if (Input.GetKeyDown(KeyCode.Q)) boolList[0] = !boolList[0];
        else if (Input.GetKeyDown(KeyCode.W)) boolList[1] = !boolList[1];
        else if (Input.GetKeyDown(KeyCode.E)) boolList[2] = !boolList[2];
        else if (Input.GetKeyDown(KeyCode.R)) boolList[3] = !boolList[3];
        else if (Input.GetKeyDown(KeyCode.T)) boolList[4] = !boolList[4];
        else if (Input.GetKeyDown(KeyCode.A)) enableTargetCovers(boolList);
        else if (Input.GetKeyDown(KeyCode.D)) disableTargetCovers(boolList);
        if (Input.anyKey) updateText();
    }

    private void enableCovers(int coversToEnable) {
        disableCovers();

        while (coversActive < coversToEnable) {
            int index = Random.Range(0, covers.Count);
            covers[index].gameObject.SetActive(true);
        }
    }

    private void disableCovers() {
        foreach (Transform t in covers) t.gameObject.SetActive(false);
    }

    public void enableTargetCovers(List<bool> coverEnable) {
        for (int i = 0; i < (coverEnable.Count < maxCoversActive ? coverEnable.Count : maxCoversActive); i++) {
            if (coverEnable[i]) covers[i].gameObject.SetActive(true);
        }
    }

    public void disableTargetCovers(List<bool> coverDisable) {
        for (int i = 0; i < (coverDisable.Count < maxCoversActive ? coverDisable.Count : maxCoversActive); i++) {
            if (coverDisable[i]) covers[i].gameObject.SetActive(false);
        }
    }

    public void updateText() {
        text.text = "";
        int count = 1;
        foreach(bool b in boolList) {
            text.text += "Cover " + count + " is selected to be " + (b ? "on" : "off") + "\n";
            count++;
        }
    }

    //public void enableWireFrame(List<bool> wireFrameEnabled) {
    //    for (int i = 0; i < (wireFrameEnabled.Count < maxCoversActive ? wireFrameEnabled.Count : maxCoversActive); i++) {
            
    //    }
    //}
}
