using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum StageEnum
{
    Forest, Winter, Matrix
}

public class StageManager : MonoBehaviour
{
    public event Action OnMapSelectEvent;

    public Player player;
    public CinemachineFreeLook freeLook;

    public Dictionary<StageEnum, GameObject[,]> MapDic = new 
        Dictionary<StageEnum, GameObject[,]>();

    public StageEnum CurrentStage { get; private set; }

    private void Awake()
    {
        SelectStage("Forest");
    }

    private void SelectStage(string name)
    {
        CurrentStage = ParseMapToEnum<StageEnum>(name);
        Debug.Log($"{CurrentStage} º±≈√µ ");
    }

    public static T ParseMapToEnum<T>(string name)
    {
        return (T)Enum.Parse(typeof(T), name, true);
    }
}
