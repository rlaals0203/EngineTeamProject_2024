using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : StageManager
{
    private int _currentHole;
    private CheckGole _checkGole;

    private void Awake()
    {
        _checkGole = player.GetComponent<CheckGole>();

        _checkGole.OnGoleEvent += HandleGole;
    }

    private void HandleGole(int stroke, string strokeName)
    {
        Debug.Log(strokeName);
        _strokes[_currentHole - 1] = stroke;

        HoleInitRoutine();
    }

    public void InitializeStage()
    {
        player.transform.position = GameObject.Find($"StartPos{_currentHole}")
            .transform.position;
    }

    public void ChangeHole()
    {
        _currentHole++;

        InitializeStage();
    }

    private IEnumerator HoleInitRoutine()
    {
        Debug.Log("재정비 시간");
        yield return new WaitForSeconds(5.0f);
        ChangeHole();
    }
}
