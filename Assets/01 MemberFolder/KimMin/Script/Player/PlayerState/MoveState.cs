using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MoveState : State
{
    public override void EnterState()
    {
        Player.IsIdle = false;
    }
}
