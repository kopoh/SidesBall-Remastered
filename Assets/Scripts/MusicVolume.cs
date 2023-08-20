using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider slider;
    public AudioSource AudioSource;
    void Start()
    { 
        slider = gameObject.GetComponent<Slider>();
        slider.value = PlayerPrefsSafe.GetFloat("volume", 0.5f);
        AudioSource.volume = slider.value;
    }

    public void OnChange()
    {
        PlayerPrefsSafe.SetFloat("volume", slider.value);
        AudioSource.volume = slider.value;
    }
}
