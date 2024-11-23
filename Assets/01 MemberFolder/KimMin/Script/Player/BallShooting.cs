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

    [SerializeField] private float _powerSensivity = 20f;
    [Range(0, 100f)] public float shootPower;

    public int stroke = 0;

    private Player _player;
    private Transform _cam;

    private bool _isHold;
    private bool _isCancel;

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
        if(_isHold && _player.CanShot && !_player.IsGole) Release();

        if (Mouse.current.leftButton.isPressed)
        {
            if (!_isCancel)
                _isHold = true;
        }
        else
            _isHold = false;

        if (Mouse.current.leftButton.wasReleasedThisFrame) _isCancel = false;
    }

    private void Release() //�� ������ ������
    {
        if (Keyboard.current.shiftKey.isPressed)
            _powerSensivity = _prevSensivity / 3f;
        else
            _powerSensivity = _prevSensivity;

        Mouse mouse = Mouse.current;
        float delta = Mathf.Round(mouse.delta.value.normalized.y);
        shootPower -= delta * _powerSensivity * Time.deltaTime;
        shootPower = Mathf.Clamp(shootPower, 0, 100);
        // ����ȭ �� ���콺 y�� �̵����� ���� �־���

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

    private void CancelShooting() //�� ���
    {
        shootPower = 0;
        _player.IsRelease = false;

        _isHold = false;
        _isCancel = true;
    }

    private void Shooting() //ī�޶� �÷��̾� �ٶ󺸴� �������� ��
    {
        _isHold = false;

        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);
        //ī�޶� y�� �÷��̾� y�� ��ȯ�� �������

        Vector3 shootDir =(_player.transform.position - fixedPos).normalized;

        if (shootPower < 25)
            shootPower /= 2;

        _player.RigidCompo.velocity = shootDir * shootPower / 4;

        stroke++;
        shootPower = 0;
        OnShootEvent?.Invoke();
    }
}
