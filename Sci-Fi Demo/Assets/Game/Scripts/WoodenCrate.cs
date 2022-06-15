using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokemCrate;

public void replaceBrokenCrate()
    {
        Instantiate(_brokemCrate, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
