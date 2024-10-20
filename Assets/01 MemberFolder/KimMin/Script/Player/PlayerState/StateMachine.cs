using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public Player Player;

    public Dictionary<StateEnum, State> stateDic = new Dictionary<StateEnum, State>();

    public void InitializeState(StateEnum state, Player player)
    {
        Player = player;
        CurrentState = stateDic[state];
        CurrentState.EnterState();
    }

    public void ChangeState(StateEnum newState)
    {
        CurrentState.ExitState();
        CurrentState = stateDic[newState];
        CurrentState.EnterState();
    }

    public void AddState(StateEnum stateEnum, State enemyState)
    {
        stateDic.Add(stateEnum, enemyState);
    }
}
