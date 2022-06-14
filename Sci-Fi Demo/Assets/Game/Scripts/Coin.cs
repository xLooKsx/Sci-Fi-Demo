using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UiManager _uiManager;

    [SerializeField]
    private AudioClip _clip;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {            
            _uiManager.showInteractionText();        
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
            Destroy(gameObject);
            _uiManager.hiddenInteractionText();
            other.GetComponent<Player>().hasACoin = true;
            _uiManager.showCoinImage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.hiddenInteractionText();
        }
    }
}
