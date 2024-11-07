using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Action<int, string> OnGoleEvent;

    private Player _player;
    private BallShooting _ballShoot;
    private string _strokeName;
    private int _par = 5;

    public void Initialize(Player player)
    {
        _player = player;
        _ballShoot = _player.GetCompo<BallShooting>();
    }

    private void OnGole()
    {
        if (_ballShoot.stroke <= 1)
        {
            _strokeName = "HOLE_IN_ONE";
        }
        else
        {
            int par = _ballShoot.stroke - _par;
            GoleEnum gole = (GoleEnum)par;
            _strokeName = gole.ToString();
        }

        _ballShoot.stroke = 0;
        OnGoleEvent?.Invoke(_ballShoot.stroke, _strokeName);
        Debug.Log(_strokeName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            OnGole();
        }
    }
}
