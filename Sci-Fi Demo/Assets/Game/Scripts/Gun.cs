using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private GameObject _shootParticleSystem;

    [SerializeField]
    private int _currentAmmo;

    [SerializeField]
    private GameObject _hitMark;
    private int _maxAmmo = 50;
    private AudioSource _audioSource;
    private bool _triggerOn = false;
    private bool _canShoot = true;
    private UiManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        _currentAmmo = _maxAmmo;
        _uiManager.updateAmmoText(_currentAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        detectReload();
    }

    private void detectReload()
    {
        if (Input.GetKey(KeyCode.R) && _currentAmmo != _maxAmmo && _canShoot)
        {
            StartCoroutine(reloadWeapon());
        }
    }

    public void weaponFire(RaycastHit hitInfo)
    {
        if (_currentAmmo > 0 && _canShoot)
        {
            _shootParticleSystem.SetActive(true);
            _triggerOn = true;
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }            
            _currentAmmo--;
            _uiManager.updateAmmoText(_currentAmmo);
            Instantiate(_hitMark, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }
    }

    public IEnumerator reloadWeapon()
    {
        _canShoot = false;
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _uiManager.updateAmmoText(_currentAmmo);
        _canShoot = true;
    }

    public void stopWeaponFire()
    {
        if (_triggerOn)
        {
            _shootParticleSystem.SetActive(false);
            _triggerOn = false;
            _audioSource.Stop();
        }
    }
}
