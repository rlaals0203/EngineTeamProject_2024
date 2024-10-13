using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Player : PlayerSetting
{
    private Dictionary<Type, IPlayerComponent> _components;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
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
}
