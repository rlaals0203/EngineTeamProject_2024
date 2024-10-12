using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestShoot : MonoBehaviour
{
    [SerializeField] private float _power;
    Vector3 shootDir;

    private Rigidbody _rigid;
    private Transform _cam;
    private Transform _player;
    public event Action OnShoot;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _cam = GameObject.Find("PlayerCamera").transform;
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
        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.position.y, _cam.position.z);

        Vector3 shootDir = (_player.position - fixedPos).normalized;

        _rigid.AddForce(shootDir * _power, ForceMode.Force);

        Debug.Log(shootDir);
        OnShoot?.Invoke();
    }
}
