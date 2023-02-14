using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;

    public void setHealt(float hp)
    {
      slider.value= hp;  
    }

    public void setMaxHealt(float max)
    {
        slider.maxValue= max;
    }
}