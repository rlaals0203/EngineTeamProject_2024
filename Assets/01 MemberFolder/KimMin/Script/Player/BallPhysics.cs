using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private bool _isSaved;
    private Vector3 _startV;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (!_isSaved)
        {
            _startV = _player.RigidCompo.velocity;
            _isSaved = true;
        }

        FixedDeceleration();
    }

    private void FixedDeceleration()
    {
        Vector3 velocity = _player.RigidCompo.velocity;
        float currentVelo = velocity.x + velocity.y;

        if (currentVelo <= _player.decelerationPoint && _player.IsShot)
        {
            _player.RigidCompo.drag = 2f;
        }
        else if(currentVelo <= _player.stopPoint)
        {
            _player.RigidCompo.velocity = Vector3.zero;
            _player.RigidCompo.drag = _player.drag;
        }

        if (_player.IsIdle)
        {
            _isSaved = false;
        }
    }
}
