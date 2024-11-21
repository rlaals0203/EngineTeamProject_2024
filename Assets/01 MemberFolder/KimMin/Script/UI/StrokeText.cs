using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrokeText : MonoBehaviour
{
    [SerializeField] private HoleManager _holeManager;
    private TextMeshProUGUI _strokeTxt;
    private BallShooting _ballShoot;

    private void Awake()
    {
        _holeManager.OnStageInitEvent += HandleMapInit;
        _strokeTxt = transform.GetComponentInChildren<TextMeshProUGUI>();
        _ballShoot = _holeManager._stageManager.player.GetComponent<BallShooting>();

        _ballShoot.OnShootEvent += HandleStrokeChanged;
    }

    private void HandleMapInit()
    {
        _strokeTxt.text = $"타수 : 0";
    }

    private void HandleStrokeChanged()
    {
        _strokeTxt.text = $"타수 : {_ballShoot.stroke}"; 
    }
}
