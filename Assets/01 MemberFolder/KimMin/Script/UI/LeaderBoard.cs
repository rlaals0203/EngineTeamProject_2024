using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private HoleManager _holeManager;
    [SerializeField] private GameObject _leaderBoard;
    [SerializeField] private TextMeshProUGUI[] _strokeTexts 
        = new TextMeshProUGUI[9];

    private bool _isOpened = false;

    private void Awake()
    {
        _leaderBoard.gameObject.SetActive(false);
        _holeManager._checkGole.OnGoleEvent += HandleOnGole;
        _holeManager._stageManager.player.GetCompo<BallShooting>()
            .OnGutterEvent += HandleGutter;
    }

    private void HandleGutter()
    {
        _strokeTexts[_holeManager._currentHole - 1].text = "-";
    }

    private void HandleOnGole(int stroke, GoleEnum gole)
    {
        _strokeTexts[_holeManager._currentHole - 1].text = stroke.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isOpened = !_isOpened;
            _leaderBoard.gameObject.SetActive(_isOpened);
        }
    }
}
