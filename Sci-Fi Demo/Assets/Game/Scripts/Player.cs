using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _characterController;
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 speedMovement = movement * _speed;
        speedMovement.y -= _gravity;
        _characterController.Move(getWorldSpace(speedMovement) * Time.deltaTime);
    }

    private Vector3 getWorldSpace(Vector3 speedMovement)
    {
        return transform.TransformDirection(speedMovement);
    }
}
