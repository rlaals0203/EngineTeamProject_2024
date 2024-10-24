using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MoveState : State
{
    public MoveState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        _player.canShot = false;
        _player.IsRelease = false;
    }

    public override void UpdateState()
    {

    }
}
