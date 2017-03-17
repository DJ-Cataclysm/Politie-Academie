using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour {
    private int sceneNr = 0;
    private List<Image> images = new List<Image>();

    public Text sceneText;
    public Image img1, img2, img3;

    private void Start() {
        images.Add(img1);
        images.Add(img2);
        images.Add(img3);   
    }

    public void NextImage() {
         // disable current image
        images[sceneNr].gameObject.SetActive(false);
        sceneNr++;
        if(sceneNr > (images.Count -1)) sceneNr = 0; 
        images[sceneNr].gameObject.SetActive(true);
        sceneText.text = "Scene " + (sceneNr + 1);
    }

    public void PrevImage() {
        images[sceneNr].gameObject.SetActive(false);
        sceneNr--;
        if (sceneNr < 0) sceneNr = images.Count - 1;
        images[sceneNr].gameObject.SetActive(true);
        sceneText.text = "Scene " + (sceneNr + 1);
    }

    public void LoadScene() {
        SceneManager.LoadScene(sceneNr + 1);
    }
}

