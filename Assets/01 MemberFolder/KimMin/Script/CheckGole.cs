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
    QUAD_BOGEY = 4
}

public class CheckGole : MonoBehaviour, IPlayerComponent
{
    public Action<string> OnGoleEvent;

    private Player _player;
    private BallShooting _ballShoot;
    private string _strokeName;
    private int _stroke;
    private int _par = 5;

    public void Initialize(Player player)
    {
        _player = player;
        _ballShoot = _player.GetCompo<BallShooting>();

        _ballShoot.OnShootEvent += HandleBallShoot;
    }

    private void HandleBallShoot()
    {
        _stroke++;
    }

    private void OnGole()
    {
        if (_stroke <= 1)
        {
            _strokeName = "HOLE_IN_ONE";
            Debug.Log(_strokeName);
            return;
        }

        int par = _stroke - _par;
        GoleEnum gole = (GoleEnum)par;
        _strokeName = gole.ToString();

        OnGoleEvent?.Invoke(_strokeName);
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
