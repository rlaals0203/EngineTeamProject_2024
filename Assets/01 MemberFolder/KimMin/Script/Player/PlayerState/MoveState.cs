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
        Player.IsIdle = false;
    }

    public override void UpdateState()
    {
        if (Player.RigidCompo.velocity == Vector3.zero)
        {
            Player.stateMachine.ChangeState(StateEnum.Idle);
        }
    }
}
