using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BallShooting : MonoBehaviour, IPlayerComponent
{
    public event Action OnShoot;

    private Player _player;
    private Transform _cam;
    private bool _isHold;

    [SerializeField] private float _power;
    [SerializeField] private GameObject _shootSlider;
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _cam = GameObject.Find("PlayerCamera").transform;
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (_isHold)
        {
            Release();
        }


        if (Input.GetMouseButton(0))
        {
            _isHold = true;
        }
        else _isHold = false;
    }

    private void Release()
    {
        if (_player.IsShot) return;

        if (!_shootSlider.gameObject.activeInHierarchy)
            _shootSlider.gameObject.SetActive(true);

        Mouse mouse = Mouse.current;
        float delta = Mathf.Round(mouse.delta.value.normalized.y);

        _power += delta;
        _fill.fillAmount = _power / 100;

        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Shooting();
            _shootSlider.gameObject.SetActive(false);
        }
        else if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            CancelShooting();
        }
    }

    private void CancelShooting()
    {
        _power = 0;
    }

    private void Shooting()
    {
        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);

        Vector3 shootDir = (_player.transform.position - fixedPos).normalized;

        _player.RigidCompo.AddForce(shootDir * _power * 10, ForceMode.Force);
        _player.IsShot = true;
        _power = 0;
        OnShoot?.Invoke();
    }

}
