using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour, IPlayerComponent
{
    public event Action OnShoot;

    private Player _player;
    private Rigidbody _rigid;
    private Transform _cam;

    private void Awake()
    {
        _cam = GameObject.Find("PlayerCamera").transform;
        _rigid = GetComponent<Rigidbody>();
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }


    private void Releasing()
    {
        float xPos = Input.GetAxis("Mouse X");
        //Debug.Log(xPos);

        if (Input.GetMouseButtonUp(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        if (!_player.IsIdle) return;

        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);
        Vector3 shootDir = (_player.transform.position - fixedPos).normalized;

        _rigid.AddForce(shootDir * _player.shootPower, ForceMode.Force);
        _player.IsShot = true;
        OnShoot?.Invoke();
    }

}
