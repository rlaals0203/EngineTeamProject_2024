using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrawDirectionLine : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private Transform _cam;

    private LineRenderer _shootDirLine;
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
        _player.GetCompo<BallShooting>().OnShootEvent += HandleShoot;
        _player.GetCompo<BallPhysics>().OnShootEndEvent += HandleShootEnd;

    }

    private void Awake()
    {
        _shootDirLine = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
        ChangeDirection();
    }

    private void HandleShoot()
    {
        _shootDirLine.enabled = false;
    }

    private void HandleShootEnd()
    {
        _shootDirLine.enabled = true;
    }

    private void ChangeDirection()
    {
        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);

        Vector3 shootDir = _player.transform.position - fixedPos;

        _shootDirLine.gameObject.transform.localRotation = Quaternion.LookRotation(shootDir, Vector2.up);
    }
}
