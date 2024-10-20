using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageEnum
{
    Forest, Winter, Matrix
}

public class StageManager : MonoBehaviour
{
    public StageEnum currentStage;
    public int currentHole;

    public void InitializeStage()
    {
        currentHole = 1;
    }
}
