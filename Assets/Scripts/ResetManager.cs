using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetManager : MonoBehaviour
{
    public UnityEvent OnHitObstacle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnHitObstacle.Invoke();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
