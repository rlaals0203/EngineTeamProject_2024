using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private bool isDecelerate = false;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        FixedDeceleration();
    }

    private void FixedDeceleration()
    {
        if (!_player.IsShot) return;

        Vector3 velocity = _player.RigidCompo.velocity;
        float currentVelo = velocity.x + velocity.y;

        if (currentVelo <= _player.decelerationPoint && !isDecelerate)
        {
            _player.PhysicsMatCompo.dynamicFriction = 2f;
            isDecelerate = true;
        }
        else if(currentVelo <= _player.stopPoint && isDecelerate)
        {
            _player.RigidCompo.velocity = Vector3.zero;
            _player.PhysicsMatCompo.dynamicFriction = 0;
            isDecelerate = false;
        }
    }
}
