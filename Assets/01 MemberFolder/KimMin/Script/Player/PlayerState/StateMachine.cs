using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    public State CurrentState { get; private set; }

    public Dictionary<StateEnum, State> stateDic = new Dictionary<StateEnum, State>();

    public void Initialize(Player player)
    {
        _player = player;
        CurrentState = stateDic[StateEnum.Idle];
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
