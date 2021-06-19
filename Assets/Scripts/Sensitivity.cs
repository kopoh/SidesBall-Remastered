using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public Slider slider;
    void Start()
    { 
        slider = gameObject.GetComponent<Slider>();
        slider.value = PlayerPrefsSafe.GetFloat("sensitivity", 40);
    }

    public void OnChange()
    {
        PlayerPrefsSafe.SetFloat("sensitivity", slider.value);
    }
}
