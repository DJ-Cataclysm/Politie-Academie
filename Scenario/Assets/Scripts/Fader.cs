using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    public Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log(material.color.a);
            StartCoroutine(FadeTo(0.0f, 3.0f));   
        }
        if (material.color.a <= 0.1f)
        {
            gameObject.SetActive(false);
        }
        
    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(material.color.r, material.color.g, material.color.b, Mathf.Lerp(alpha, aValue, t));
            material.color = newColor;
            yield return null;
        }
    }

}
