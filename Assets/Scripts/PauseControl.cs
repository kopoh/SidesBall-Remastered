using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{ 
    public static bool gameIsPause;
    public Rigidbody player;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        //player.isKinematic = true;
        AudioListener.pause = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        //player.isKinematic = false;
        AudioListener.pause = false;
    }
}
