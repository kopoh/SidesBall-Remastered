using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuMiniGame : MonoBehaviour
{
    [Range(1, 10)] public float Delta;
    public GameObject StartObj;
    public GameObject FinishObj; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MenuGameSphere"))
        {
            if (transform.position.y <= FinishObj.transform.position.y + 1)
            {
                other.transform.position = new Vector3(Random.Range(-14, 14), StartObj.transform.position.y,
                    StartObj.transform.position.z);
            }
        }
    }
    
}