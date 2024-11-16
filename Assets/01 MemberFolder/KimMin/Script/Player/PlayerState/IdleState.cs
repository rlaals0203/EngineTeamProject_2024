using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        _player.CanShot = true;
    }

    public override void UpdateState()
    {
        if (_player.playerVelocity >= _player.stopPoint * 2)
        {
            _stateMachine.ChangeState(StateEnum.Move);
        }
    }
}
