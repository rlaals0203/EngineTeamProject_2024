using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TextCore.Text;
using UnityEngine;

public enum StageEnum
{
    Forest, Winter, Matrix
}

public class StageManager : MonoBehaviour
{
    public event Action OnMapSelectEvent;

    [HideInInspector] public GameObject[] map;
    public GameObject mapParent;
    public Player player;
    public CinemachineFreeLook freeLook;

    public Dictionary<StageEnum, GameObject[,]> MapDic = new 
        Dictionary<StageEnum, GameObject[,]>();

    public float[] holeTime = new float[12];
    public int[] strokes = new int[12];
    public int[] pars = new int[12];

    public float totalTime;
    public int totalStroke;

    public StageEnum CurrentStage { get; private set; }

    private void Awake()
    {
        SelectStage("Forest");
        mapParent = GameObject.Find("Map");
        
        DontDestroyOnLoad(gameObject);
    }

    private void SelectStage(string name)
    {
        CurrentStage = ParseMapToEnum<StageEnum>(name);
    }

    public static T ParseMapToEnum<T>(string name)
    {
        return (T)Enum.Parse(typeof(T), name, true);
    }
}
