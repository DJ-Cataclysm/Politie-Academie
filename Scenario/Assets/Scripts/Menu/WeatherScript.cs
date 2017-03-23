using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherScript : MonoBehaviour {

    public GameObject RainEffect;

	// Use this for initialization
	void Start () { 
        print("weather value: " + SliderScript.weatherSwitch);
        changeWeather();
	}

    public void changeWeather() {
        if (SliderScript.weatherSwitch == 0) {
            print("weather: Sun");
            RainEffect.SetActive(false);
        }
        else if (SliderScript.weatherSwitch == 1){
            print("weather: Rain");
            RainEffect.SetActive(true);
        }
    }
}
