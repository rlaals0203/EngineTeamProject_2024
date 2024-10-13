using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public event Action OnShoot;

    [SerializeField] private float _shootPower;

    private Rigidbody _rigid;
    private Transform _cam;
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _cam = GameObject.Find("PlayerCamera").transform;
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Releasing();
        }
    }

    private void Releasing()
    {
        float xPos = Input.GetAxis("Mouse X");
        Debug.Log(xPos);

        if (Input.GetMouseButtonUp(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.position.y, _cam.position.z);
        Vector3 shootDir = (_player.position - fixedPos).normalized;

        _rigid.AddForce(shootDir * _shootPower, ForceMode.Force);
        OnShoot?.Invoke();
    }
}
