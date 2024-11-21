using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private BallShooting _ballShooting;
    [SerializeField] private CheckGole _checkGole;
    [SerializeField] private float _time;

    private float _startTime;

    private TextMeshProUGUI _timerTxt;

    private bool _isRunning = false;

    private void Awake()
    {
        _timerTxt = GetComponentInChildren<TextMeshProUGUI>();

        _ballShooting.OnShootEvent += HandleOnShoot;
        _checkGole.OnGoleEvent += HandleOnGole;

        _startTime = _time;
    }

    private void HandleOnGole(int arg1, GoleEnum @enum)
    {
        _isRunning = false;
        _time = _startTime;
        _timerTxt.text = $"{_startTime}��";
        _timerTxt.transform.DOLocalMoveY(10f, 0.5f).SetEase(Ease.OutExpo);
    }

    private void HandleOnShoot()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _timerTxt.text = $"{_time}��";
            _timerTxt.transform.DOLocalMoveY(- 10f, 0.5f).SetEase(Ease.OutExpo);
        }
    }

    private void Update()
    {
        if (_isRunning)
        {
            _time -= Time.deltaTime;
            _timerTxt.text = $"{Mathf.RoundToInt(_time)}��";
        }
    }
}
