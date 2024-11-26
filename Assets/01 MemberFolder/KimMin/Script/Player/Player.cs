using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum StateEnum
{
    Idle, Move, Release, Gole
}

public class Player : PlayerSetting
{
    private Dictionary<Type, IPlayerComponent> _components;
    public StateMachine stateMachine;
    public List<Vector3> ballPoints;

    public override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine();

        stateMachine.AddState(StateEnum.Idle, new IdleState(this, stateMachine));
        stateMachine.AddState(StateEnum.Move, new MoveState(this, stateMachine));
        stateMachine.InitializeState(StateEnum.Idle, this);

        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
    }

    private void Start()
    {
        RigidCompo.position = new Vector3(0, 1, 0);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();

        if (float.IsInfinity(RigidCompo.velocity.magnitude) || float.IsNaN(RigidCompo.velocity.magnitude))
        {
            RigidCompo.velocity = Vector3.zero;
        }

        if (RigidCompo.velocity.magnitude > MAX_SPEED)
        {
            RigidCompo.velocity = RigidCompo.velocity.normalized * MAX_SPEED;
        }
    }

    public T GetCompo<T>() where T : class
    {
        Type type = typeof(T);
        if (_components.TryGetValue(type, out IPlayerComponent component))
        {
            return component as T;
        }
        return default;
    }

    public void ResetPhysics()
    {
        RigidCompo.velocity = Vector3.zero;
        RigidCompo.angularVelocity = Vector3.zero;
        RigidCompo.drag = startDrag;
    }
}
