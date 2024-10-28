using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinGimic : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime * _speed;

        transform.rotation = Quaternion.Euler(0, _time, 0);
    }
}
