using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private HoleManager _holeManager;
    [SerializeField] private CheckGole _checkGole;
    [SerializeField] private float _time;

    private float _startTime;

    private TextMeshProUGUI _timerTxt;

    private bool _isRunning = false;

    private void Awake()
    {
        _timerTxt = GetComponentInChildren<TextMeshProUGUI>();

        _holeManager._stageManager.player.GetComponent<BallShooting>()
            .OnShootEvent += HandleOnShoot;

        _checkGole.OnGoleEvent += HandleOnGole;

        _startTime = _time;
    }

    private void HandleOnGole(int arg1, GoleEnum goleEnum)
    {
        _isRunning = false;
        _holeManager._stageManager.holeTime[_holeManager._currentHole - 1] = _startTime - _time;
        _time = _startTime;
        _timerTxt.text = $"{_startTime}√ ";
    }

    private void HandleOnShoot()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _timerTxt.text = $"{_time}√ ";
        }
    }

    private void Update()
    {
        if (_isRunning)
        {
            _time -= Time.deltaTime;
            _timerTxt.text = $"{Mathf.RoundToInt(_time)}√ ";
        }

        if(_time < 0)
            _checkGole.OnGole(true);
    }
}
