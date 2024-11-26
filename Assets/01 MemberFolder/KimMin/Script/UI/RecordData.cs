using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;
using DG.Tweening;

public class RecordData : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _dontClick;

    [SerializeField] private TextMeshProUGUI _stroke;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _dateTime;

    private List<string> recordData = new List<string>();

    private bool _isOpened;

    private void Awake()
    {
        recordData = File.ReadAllLines(@"gameData.txt").ToList();

        if (recordData.Count < 3) return;

        _stroke.text = recordData[0];
        _time.text = $"{Mathf.RoundToInt(float.Parse(recordData[1]))}ÃÊ";
        _dateTime.text = recordData[2];
    }

    public void OnClick()
    {
        _isOpened = !_isOpened;

        if (_isOpened)
            _panel.transform.DOMoveY(200, 0.5f);
        else
            _panel.transform.DOMoveY(1200, 0.5f);
    }
}
