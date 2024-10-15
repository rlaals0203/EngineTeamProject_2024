using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BallShooting : MonoBehaviour, IPlayerComponent
{
    public event Action OnShoot;

    private Player _player;
    private Transform _cam;

    private void Awake()
    {
        _cam = GameObject.Find("PlayerCamera").transform;
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

    private void Shooting()
    {
        if (_player.IsShot) return;

        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);
        Vector3 shootDir = (_player.transform.position - fixedPos).normalized;

        _player.RigidCompo.AddForce(shootDir * _player.shootPower, ForceMode.Force);
        _player.IsShot = true;
        OnShoot?.Invoke();
    }

}
