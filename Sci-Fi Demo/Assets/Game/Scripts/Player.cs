using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _characterController;
    private float _speed = 3.5f;
    private float _gravity = 9.81f;

    public bool hasACoin = false;

    [SerializeField]
    public Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        configMouse();
        _characterController = GetComponent<CharacterController>();
    }

    private static void configMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        exitGame();
        movement();
        detectShootButton();
    }

    private void detectShootButton()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                gun.weaponFire(hitInfo);

                WoodenCrate woodenCrate = hitInfo.transform.gameObject.GetComponent<WoodenCrate>();
                if (woodenCrate != null)
                {
                    woodenCrate.replaceBrokenCrate();
                }
            }
        }
        if (!Input.GetMouseButton(0))
        {
            gun.stopWeaponFire();
        }
    }

    private void exitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }        
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

    public void tradeWeaponByCoin()
    {
        gun.gameObject.SetActive(true);
        hasACoin = false;
    }
}
