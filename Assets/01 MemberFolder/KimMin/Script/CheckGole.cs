using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public enum GoleEnum
{
    HOLE_IN_ONE = -100,
    CONDOR = -4,
    ALBATROSS = -3,
    EAGLE = -2,
    BIRDIE = -1,
    PAR = 0,
    BOGEY = 1,
    DOUBLE_BOGEY = 2,
    TRIPLE_BOGEY = 3,
    QUADRUPLE_BOGEY = 4,
    QUINTUPLE_BOGEY = 5,
    SEXTUPLE_BOGEY = 6,
    SEPTUPLE_BOGEY = 7
}

public class CheckGole : MonoBehaviour, IPlayerComponent
{
    public Action<int, GoleEnum> OnGoleEvent;

    public Dictionary<GoleEnum, Color> strokeDic = new Dictionary<GoleEnum, Color>();

    private Player _player;
    private BallShooting _ballShoot;
    private int _par = 5;

    public void Initialize(Player player)
    {
        _player = player;
        _ballShoot = _player.GetCompo<BallShooting>();

        _player.GetCompo<BallPhysics>().OnShootEndEvent += HandleOnShotEnd;

        #region DictionaryAdd
        strokeDic.Add(GoleEnum.HOLE_IN_ONE, new Color(250, 190, 65, 255));
        strokeDic.Add(GoleEnum.CONDOR, new Color(200, 60, 250, 255));
        strokeDic.Add(GoleEnum.ALBATROSS, new Color(250, 250, 150, 255));
        strokeDic.Add(GoleEnum.EAGLE, new Color(255, 100, 0, 255));
        strokeDic.Add(GoleEnum.BIRDIE, new Color(100, 255, 255, 255));
        strokeDic.Add(GoleEnum.PAR, new Color(255, 255, 255, 255));
        strokeDic.Add(GoleEnum.BOGEY, new Color(200, 200, 200, 255));
        strokeDic.Add(GoleEnum.DOUBLE_BOGEY, new Color(175, 175, 175, 255));
        strokeDic.Add(GoleEnum.TRIPLE_BOGEY, new Color(150, 150, 150, 255));
        strokeDic.Add(GoleEnum.QUADRUPLE_BOGEY, new Color(125, 125, 125, 255));
        strokeDic.Add(GoleEnum.QUINTUPLE_BOGEY, new Color(100, 100, 100, 255));
        strokeDic.Add(GoleEnum.SEXTUPLE_BOGEY, new Color(75, 75, 75, 255));
        strokeDic.Add(GoleEnum.SEPTUPLE_BOGEY, new Color(50, 50, 50, 255));
        #endregion
    }

    private void HandleOnShotEnd()
    {
        _player._ballPoints.Add(_player.transform.position);
    }

    private void OnGole()
    {
        if (_player.RigidCompo.velocity == Vector3.zero || _player.IsGole) return;

        int par = _ballShoot.stroke > 1 ? _ballShoot.stroke - _par : -100;
        GoleEnum gole = (GoleEnum)par;

        OnGoleEvent?.Invoke(_ballShoot.stroke, gole);

        _player.StopImmediatly();
        _player.IsGole = true;
        _player._ballPoints = new List<Vector3>();

        _ballShoot.stroke = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            OnGole();
        }
    }
}
