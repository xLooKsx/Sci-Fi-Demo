using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharkman : MonoBehaviour
{

    private UiManager _uiManager;
    private Player _player;
    private AudioSource _audioSource;

    private bool _messageDisplay = false;
    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if (_player.hasACoin)
            {
                _uiManager.showInteractionText();
                _messageDisplay = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(_messageDisplay && Input.GetKeyDown(KeyCode.E))
        {
            _player.tradeWeaponByCoin();
            messageDisable();
            _uiManager.hideCoinImage();
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_messageDisplay)
        {
            messageDisable();
        }
    }

    private void messageDisable()
    {
        _uiManager.hiddenInteractionText();
        _messageDisplay = false;
    }
}
