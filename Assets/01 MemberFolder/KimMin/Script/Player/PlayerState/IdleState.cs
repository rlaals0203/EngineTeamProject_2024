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
        Player.IsIdle = true;
    }

    public override void UpdateState()
    {
        if (Player.RigidCompo.velocity != Vector3.zero)
        {
            Player.stateMachine.ChangeState(StateEnum.Move);
        }
    }
}
