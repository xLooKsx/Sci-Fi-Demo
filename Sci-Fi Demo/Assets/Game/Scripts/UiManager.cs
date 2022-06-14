using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ammoText;
 public void updateAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
}
