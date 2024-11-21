using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public event Action OnStageInitEvent;

    public float timeToReady = 4.0f;
    public int _currentHole;
    public CheckGole _checkGole;
    public StageManager _stageManager;

    private void Awake()
    {
        _stageManager = GetComponent<StageManager>();
        _checkGole = _stageManager.player.GetComponent<CheckGole>();

        _checkGole.OnGoleEvent += HandleGole;

        _currentHole = 1;
        InitializeStage(_currentHole);
    }

    private void HandleGole(int stroke, GoleEnum gole)
    {
        _stageManager._strokes[_currentHole - 1] = stroke;

        Debug.Log($"Å¸¼ö : {stroke}, {gole}");

        StartCoroutine(HoleInitRoutine());
    }

    public void InitializeStage(int hole)
    {
        _stageManager.player.transform.position = _stageManager.map[hole - 1]
                            .transform.Find("End")
                            .transform.Find("StartPos").position;

        _stageManager.player.IsGole = false;
        _stageManager.player.ballPoints.Clear();
        OnStageInitEvent?.Invoke();
    }

    private IEnumerator HoleInitRoutine()
    {
        yield return new WaitForSeconds(timeToReady);
        InitializeStage(++_currentHole);
    }
}
