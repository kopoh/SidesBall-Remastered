using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseScript : MonoBehaviour
{
    public UnityEvent LoseEvent;

    void Start()
    {
        if (LoseEvent == null)
            LoseEvent = new UnityEvent();

        LoseEvent.AddListener(Ping);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && LoseEvent != null)
        {
            LoseEvent.Invoke();
        }
    }

    void Ping()
    {
        Debug.Log("Ping");
    }
}