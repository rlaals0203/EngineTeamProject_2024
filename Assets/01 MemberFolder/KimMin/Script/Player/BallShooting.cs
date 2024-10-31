using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BallShooting : MonoBehaviour, IPlayerComponent
{
    public event Action OnShootEvent;

    [Range(0, 100f)] public float shootPower;
    public int stroke = 0;

    private Player _player;
    private Transform _cam;

    private bool _isHold;
    private bool _isCancel;
    private bool isFine = false;

    [SerializeField] private float _powerSensivity = 20f;
    private float _prevSensivity;

    private void Awake()
    {
        _cam = GameObject.Find("PlayerCamera").transform;
        _prevSensivity = _powerSensivity;
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if(_isHold && _player.canShot)
        {
            Release();
        }

        if (Mouse.current.leftButton.isPressed)
        {
            if (!_isCancel)
                _isHold = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame) _isCancel = false;
    }

    private void Release() //꾹 누르고 있을때
    {
        if (Keyboard.current.shiftKey.isPressed)
            _powerSensivity = _prevSensivity / 3f;
        else
            _powerSensivity = _prevSensivity;

        Mouse mouse = Mouse.current;
        float delta = Mathf.Round(mouse.delta.value.normalized.y);
        shootPower -= delta * _powerSensivity * Time.deltaTime;
        shootPower = Mathf.Clamp(shootPower, 0, 100);
        // 정규화 한 마우스 y축 이동값을 값을 넣어줌

        _player.IsRelease = true;

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Shooting();
        }
        else if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            CancelShooting();
        }
    }

    private void CancelShooting() //슛 취소
    {
        shootPower = 0;
        _player.IsRelease = false;

        _isHold = false;
        _isCancel = true;
    }

    private void Shooting() //카메라가 플레이어 바라보는 방향으로 슛
    {
        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);
        //카메라 y를 플레이어 y로 변환해 계산해줌

        Vector3 shootDir =(_player.transform.position - fixedPos).normalized;

        //_player.RigidCompo.AddForce(shootDir * shootPower * 10, ForceMode.Force);
        _player.RigidCompo.velocity = shootDir * shootPower / 2;

        _isHold = false;

        stroke++;
        shootPower = 0;
        OnShootEvent?.Invoke();
    }
}
