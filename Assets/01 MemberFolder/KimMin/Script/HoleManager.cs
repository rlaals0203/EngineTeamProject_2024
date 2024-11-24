using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public event Action OnStageInitEvent;
    public event Action OnGameEndEvent;

    public float timeToReady = 4.0f;
    public int _currentHole;
    public CheckGole _checkGole;
    public StageManager _stageManager;

    private Vector3 nextPos;

    private void Awake()
    {
        _stageManager = GetComponent<StageManager>();
        _checkGole = _stageManager.player.GetComponent<CheckGole>();

        _checkGole.OnGoleEvent += HandleGole;

        Initialize();
    }

    private void Initialize()
    {
        for(int i = 0; i < _stageManager.strokes.Length; i++)
        {
            _stageManager.map[i] = _stageManager.mapParent.transform.Find($"Stage-{i + 1}").gameObject;
            _stageManager.strokes[i] = 13;
        }

        _currentHole = 1;
        InitializeStage(_currentHole);
    }

    private void HandleGole(int stroke, GoleEnum gole)
    {
        if (_currentHole >= 12)
        {
            StartCoroutine(GameEndRoutine());
            return;
        }

        _stageManager.strokes[_currentHole - 1] = stroke;

        StartCoroutine(HoleInitRoutine());
    }

    public void InitializeStage(int hole)
    {
        _stageManager.player.transform.position = nextPos;
        _stageManager.player.IsGole = false;
        _stageManager.player.ballPoints.Clear();
        OnStageInitEvent?.Invoke();
    }

    private IEnumerator HoleInitRoutine()
    {
        nextPos = _stageManager.map[_currentHole]
                    .transform.Find("End")
                    .transform.Find("StartPos").position;

        yield return new WaitForSeconds(timeToReady);
        InitializeStage(++_currentHole);
    }

    private IEnumerator GameEndRoutine()
    {
        _stageManager.strokes.ToList().ForEach(x => _stageManager.totalStroke += x);
        _stageManager.holeTime.ToList().ForEach(x => _stageManager.totalTime += x);

        yield return new WaitForSeconds(timeToReady);
        OnGameEndEvent?.Invoke();
    }
}
