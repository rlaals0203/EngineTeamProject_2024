using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinGimic : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _currentRot;

    private void Awake()
    {
        _currentRot = transform.rotation.y * _speed;
    }

    private void Update()
    {
        _currentRot += Time.deltaTime * _speed;

        transform.rotation = Quaternion.Euler(0, _currentRot, 0);
    }
}
