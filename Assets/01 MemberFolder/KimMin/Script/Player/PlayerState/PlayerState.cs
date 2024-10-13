using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public State _currentState, _prevState = null;

    private void Awake()
    {
        _currentState = TransitionState(StateEnum.Idle);
    }

    public void TransitionState(State newState)
    {
        if (newState == null) return;

        if (_currentState != null)
            _currentState.ExitState();

        _prevState = _currentState;
        _currentState = newState;
        _currentState.EnterState();
    }
}
