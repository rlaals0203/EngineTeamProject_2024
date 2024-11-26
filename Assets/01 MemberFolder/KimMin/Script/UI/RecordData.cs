using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class RecordData : MonoBehaviour
{
    private List<string> recordData = new List<string>();
    [SerializeField] private TextMeshProUGUI _stroke;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _dateTime;

    private void Awake()
    {
        recordData = File.ReadAllLines(@"aaa.txt").ToList();

        if (recordData.Count < 3) return;

        _stroke.text = recordData[0];
        _time.text = $"{Mathf.RoundToInt(float.Parse(recordData[1]))}ÃÊ";
        _dateTime.text = recordData[2];
    }
}
