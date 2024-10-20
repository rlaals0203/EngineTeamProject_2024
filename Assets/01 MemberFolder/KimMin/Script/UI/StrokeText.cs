using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrokeText : MonoBehaviour
{
    Player _player;
    TextMeshProUGUI _strokeTxt;
    BallShooting _ballShoot;

    private void Awake()
    {
        _player = GameObject.Find("Player")?.GetComponent<Player>();
        _strokeTxt = transform.Find("StrokeText")?.GetComponent<TextMeshProUGUI>();
        _ballShoot = _player.GetComponent<BallShooting>();

        _ballShoot.OnShootEvent += HandleStrokeChanged;
    }

    private void HandleStrokeChanged()
    {
        _strokeTxt.text = $"Stroke : {_ballShoot.stroke}"; 
    }
}
