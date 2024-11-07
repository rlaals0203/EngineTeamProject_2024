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
    }

    private void HandleOnGole(int stroke, string strokeText)
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
