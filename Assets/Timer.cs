using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;

    // Function for setting value on timer
    public void SetTime(int time)
    {
        slider.value = time;
    }
}
