using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private GameObject _background;
    private Image _fill;

    private BallShooting _ballShooting;
    private CinemachineFreeLook _freeLookCam;

    private bool _isActive;

    public void Awake()
    {
        _ballShooting = _player.GetComponent<BallShooting>();

        try
        {
            _freeLookCam = GameObject.Find("BallCamera").GetComponent<CinemachineFreeLook>();
        }
        catch(NullReferenceException ex)
        {
            Debug.Log(ex.Message);
        }

        _background = transform.Find("Background").gameObject;
        _fill = _background.transform.Find("Fill").GetComponent<Image>();
    }

    private void Update()
    {
        if (_player.IsRelease && _ballShooting.shootPower > 0.1f)
        {
            ChangeSlider();
            ActiveObjects(true);
        }
        else if (_player.IsRelease && _ballShooting.shootPower <= 0f)
        {
            _ballShooting.CancelShooting();
            ActiveObjects(false);
        }
        else
        {
            ActiveObjects(false);
        }
    }

    private void ChangeSlider()
    {
        _fill.fillAmount = _ballShooting.shootPower / 100;
    }

    private void ActiveObjects(bool active)
    {
        if (_isActive == active)
            return;

        _isActive = active;

        _background.SetActive(active);
        _freeLookCam.enabled = !active;
    }
}
