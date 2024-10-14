using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    Idle, Move, Release, Gole
}

public abstract class State : MonoBehaviour, IPlayerComponent
{
    public Player Player { get; private set; }

    public void Initialize(Player player)
    {
        Player = player;
    }

    public virtual void EnterState() { }

    public virtual void UpdateState() { }

    public virtual void ExitState() { }

}
