using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    private int _currentHole;
    private CheckGole _checkGole;
    private StageManager _stageManager;

    private void Awake()
    {
        _stageManager = GetComponent<StageManager>();
        _checkGole = _stageManager.player.GetComponent<CheckGole>();

        _checkGole.OnGoleEvent += HandleGole;

        _currentHole = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _checkGole.OnGoleEvent?.Invoke(1, "HIO");
        }
    }

    private void HandleGole(int stroke, string strokeName)
    {
        _stageManager._strokes[_currentHole - 1] = stroke;

        Debug.Log($"Ÿ�� : {stroke}, {strokeName}");

        StartCoroutine(HoleInitRoutine());
    }

    public void InitializeStage(int hole)
    {
        _stageManager.player.transform.position = _stageManager.testMaps
                    [hole].transform.Find("StartPos").transform.position;
    }

    private IEnumerator HoleInitRoutine()
    {
        Debug.Log("������ �ð�");
        yield return new WaitForSeconds(5.0f);
        InitializeStage(++_currentHole);
    }
}
