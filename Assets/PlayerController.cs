using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Speed = 1;
    public float sensitivity = 12f;
    public Rigidbody _player;

    void Start()
    {
        _player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _player.AddForce(Input.acceleration.x * sensitivity, 0, Time.deltaTime * Speed, ForceMode.Force);
    }
}
