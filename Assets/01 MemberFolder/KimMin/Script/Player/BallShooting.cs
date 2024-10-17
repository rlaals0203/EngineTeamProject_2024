using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BallShooting : MonoBehaviour, IPlayerComponent
{
    public float shootPower;
    private Player _player;
    private Transform _cam;
    private bool _isHold;

    [SerializeField] private float _powerSensivity = 10f;

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
        if(_isHold)
        {
            if (_player.IsShot) return;

            Release();
        }

        if (Mouse.current.leftButton.isPressed)
        {
            _isHold = true;
        }
    }

    private void Release() //�� ������ ������
    {
        Mouse mouse = Mouse.current;
        float delta = Mathf.Round(mouse.delta.value.normalized.y);

        shootPower += delta * _powerSensivity * Time.deltaTime; // ����ȭ �� ���콺 y�� �̵����� ���� �־���
        shootPower = Mathf.Clamp(shootPower, 0, 100);

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
    }

    private void Shooting() //ī�޶� �÷��̾� �ٶ󺸴� �������� ��
    {
        _player.IsShot = true;

        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);
        //ī�޶� y�� �÷��̾� y�� ��ȯ�� �������

        Vector3 shootDir =(_player.transform.position - fixedPos).normalized;

        _player.RigidCompo.AddForce(shootDir * shootPower * 10, ForceMode.Force);

        shootPower = 0;
        _isHold = false;
        _player.IsRelease = false;
    }
}
