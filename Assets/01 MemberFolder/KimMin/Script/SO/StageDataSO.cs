using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/StageDataSO")]
public class StageDataSO : ScriptableObject
{
    public int totalStroke;
    public int totalTime;

    public StageManager stageManager;
}
