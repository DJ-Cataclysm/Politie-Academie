using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour {
    public Slider slider;
    public static int dayNight;
  
    public void setDayNight() {
        dayNight = (int)slider.value;
        print("DayNight value: " + dayNight);
    }
}
