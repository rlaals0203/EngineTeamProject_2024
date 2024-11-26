using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        _player.CanShot = false;
        _player.IsRelease = false;
    }

    public override void UpdateState()
    {
    }
}
