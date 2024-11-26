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

    [SerializeField] private float _powerSensivity = 27.5f;
    [Range(0, 100f)] public float shootPower;

    private Player _player;
    private Transform _cam;

    public int stroke = 0;
    public int ballPointCnt = 0;

    public bool isHold;
    public bool isCancel;

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
        if(isHold && _player.CanShot && !_player.IsGole) Release();

        if (Mouse.current.leftButton.isPressed)
        {
            if (!isCancel)
                isHold = true;
        }
        else
            isHold = false;

        if (Mouse.current.leftButton.wasReleasedThisFrame) isCancel = false;
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

    public void CancelShooting() //�� ���
    {
        shootPower = 0;
        _player.IsRelease = false;

        isHold = false;
        isCancel = true;
    }

    private void Shooting() //ī�޶� �÷��̾� �ٶ󺸴� �������� ��
    {
        if (isCancel) return;

        isHold = false;

        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);
        //ī�޶� y�� �÷��̾� y�� ��ȯ�� �������

        Vector3 shootDir =(_player.transform.position - fixedPos).normalized;

        if (_player.RigidCompo.interpolation != RigidbodyInterpolation.Interpolate)
            _player.RigidCompo.interpolation = RigidbodyInterpolation.Interpolate;

        if (shootPower < 25)
            shootPower /= 2;

        _player.RigidCompo.velocity = shootDir * shootPower / 4;

        ballPointCnt++;
        stroke++;
        shootPower = 0;
        OnShootEvent?.Invoke();
        SFXSoundManager.instance.OnShotClip?.Invoke();
    }
}
