using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour {
    public Slider slider;
    public static int dayNight;
    public static int weatherSwitch;
  
    public void setWeather() {
        weatherSwitch = (int)slider.value;
        print("Weather value: " + weatherSwitch);
    }

    public void setVolume() {
        AudioListener.volume = slider.value;
    }


    public void setDayNight() {
            dayNight = (int)slider.value;
            print("DayNight value: " + dayNight);
    }
}
