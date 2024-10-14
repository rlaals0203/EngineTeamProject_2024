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
        _player.IsIdle = false;
    }

    public override void UpdateState()
    {
        if (_player.RigidCompo.velocity == Vector3.zero)
        {
            _stateMachine.ChangeState(StateEnum.Idle);
        }
    }
}
