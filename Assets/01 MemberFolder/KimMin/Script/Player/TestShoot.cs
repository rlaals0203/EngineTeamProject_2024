using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShoot : MonoBehaviour
{
    [SerializeField] private float _power;

    private Rigidbody _rigid;
    private Transform _ballCam;
    public event Action OnShoot;

    private void Awake()
    {
        _ballCam = GameObject.Find("BallCamera").transform;
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        Vector3 shootDir = (_ballCam.position - transform.position).normalized;
        _rigid.AddForce(-shootDir * _power, ForceMode.Impulse);

        OnShoot?.Invoke();
    }
}
