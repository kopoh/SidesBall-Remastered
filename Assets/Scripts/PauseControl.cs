using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{ 
    public static bool gameIsPause;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}

