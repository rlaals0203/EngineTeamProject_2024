using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.IO;

public class HoleManager : MonoBehaviour
{
    public event Action OnStageInitEvent;
    public event Action OnGameEndEvent;

    public float timeToReady = 4.0f;
    public int _currentHole;
    public CheckGole _checkGole;
    public StageManager _stageManager;
    private Rigidbody _rigid;
    private Vector3 nextPos;

    private void Awake()
    {
        _stageManager = GetComponent<StageManager>();
        _checkGole = _stageManager.player.GetComponent<CheckGole>();
        _rigid = _stageManager.player.GetComponent<Rigidbody>();

        _rigid.isKinematic = false;
        _checkGole.OnGoleEvent += HandleGole;

        Initialize();
    }

    private void Initialize()
    {
        _stageManager.strokeNameDic.Clear();

        _stageManager.strokeNameDic.Add(GoleEnum.HOLE_IN_ONE, 0);
        _stageManager.strokeNameDic.Add(GoleEnum.CONDOR, 0);
        _stageManager.strokeNameDic.Add(GoleEnum.ALBATROSS, 0);
        _stageManager.strokeNameDic.Add(GoleEnum.EAGLE, 0);
        _stageManager.strokeNameDic.Add(GoleEnum.BIRDIE, 0);
        _stageManager.strokeNameDic.Add(GoleEnum.PAR, 0);

        for (int i = 0; i < _stageManager.strokes.Length; i++)
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

        _stageManager.player.ResetPhysics();

        _stageManager.strokes[_currentHole - 1] = stroke;

        StartCoroutine(HoleInitRoutine());
    }

    public void InitializeStage(int hole)
    {
        _stageManager.player.ResetPhysics();
        _stageManager.player.IsGole = false;
        _stageManager.player.ballPoints.Clear();
        OnStageInitEvent?.Invoke();

        if (hole > 1)
        {
            _stageManager.player.RigidCompo.interpolation = RigidbodyInterpolation.None;
            _stageManager.player.transform.position = nextPos;
            _stageManager.player.ballPoints.Add(nextPos);
        }
        else
        {
            Vector3 startPos = new Vector3(236.7f, 2.4f, 546);
            _stageManager.player.RigidCompo.position = startPos;
            _stageManager.player.ballPoints.Add(startPos);
        }
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

        using (StreamWriter sw = new StreamWriter(File.Open(@"gameData.txt",FileMode.OpenOrCreate)))
        {
            sw.WriteLine(_stageManager.totalStroke);
            sw.WriteLine(_stageManager.totalTime);
            sw.WriteLine(DateTime.Now);
            sw.Close();
        }

        _stageManager.stageDataSO.totalStroke = _stageManager.totalStroke;
        _stageManager.stageDataSO.totalTime = Mathf.RoundToInt(_stageManager.totalTime);

        yield return new WaitForSeconds(timeToReady);
        OnGameEndEvent?.Invoke();
    }
}
