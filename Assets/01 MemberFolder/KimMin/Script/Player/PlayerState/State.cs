using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player _player;
    protected StateMachine _stateMachine;

    public State(Player player, StateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
    }

    public Player Player { get; private set; }

    public virtual void EnterState() { }

    public virtual void UpdateState() { }

    public virtual void ExitState() { }
}
