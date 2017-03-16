using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private Transform directionalLight; //the transform off the light, here we can change the rotation


    public Light light; // the light's Light component, here we can change the intensity


    //an enum for all the possible times
    //public enum timeList
    //{
    //    Day = 1,
    //    Dim = 2,
    //    Night = 3,
    //}


    // Use this for initialization
    void Start()
    {
        directionalLight = GetComponent<Transform>(); //gets the transform for the light
        changeTime();
    }

    public void changeTime()
    {
        print("dag/nacht: " + SliderScript.dayNight);
        //day
        if (SliderScript.dayNight == 0)
        {
            print("day");
            directionalLight.rotation = Quaternion.AngleAxis(90, new Vector3(90, 0, 0));
            light.intensity = 1;
        }
        //dim
        else if (SliderScript.dayNight == 1)
        {
            print("dim");
            directionalLight.rotation = Quaternion.AngleAxis(22.5f, new Vector3(22.5f, 0, 0));
            light.intensity = 0.25f;
        }
        //night
        else if (SliderScript.dayNight == 2)
        {
            print("night");
            directionalLight.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 0));
            light.intensity = 0;
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("d"))
    //    {
    //        directionalLight.rotation = Quaternion.AngleAxis(90, new Vector3(90, 0, 0));
    //        light.intensity = 1;
    //    }
    //    else if (Input.GetKeyDown("s"))
    //    {
    //        directionalLight.rotation = Quaternion.AngleAxis(22.5f, new Vector3(22.5f, 0, 0));
    //        light.intensity = 0.25f;
    //    }
    //    else if (Input.GetKeyDown("n"))
    //    {
    //        directionalLight.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 0));
    //        light.intensity = 0;
    //    }
    //}
}
