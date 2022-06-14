using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ammoText;

    [SerializeField]
    private TextMeshProUGUI interactionText;

    [SerializeField]
    private Image _coinImage;

    private void Start()
    {
        //interactionText.enabled = false;
    }
    public void updateAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void showInteractionText()
    {
        interactionText.gameObject.SetActive(true);
    }

    public void hiddenInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    public void showCoinImage()
    {
        _coinImage.gameObject.SetActive(true);
    }

    public void hideCoinImage()
    {
        _coinImage.gameObject.SetActive(false);
    }
}
