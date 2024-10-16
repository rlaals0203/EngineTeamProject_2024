using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private bool isDecelerate = false;
    private bool isStop = false;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (_player.IsShot)
            FixedDeceleration();
    }

    private void FixedDeceleration()
    {
        float speed = _player.RigidCompo.velocity.magnitude;

        if (speed <= _player.decelerationPoint && !isDecelerate)
        {
            _player.RigidCompo.drag = 1f;
            isDecelerate = true;
        }
        else if(speed <= _player.stopPoint && !isStop)
        {
            _player.RigidCompo.velocity = Vector3.zero;
            _player.RigidCompo.angularVelocity = Vector3.zero;
            _player.RigidCompo.drag = _player.drag;
            isStop = true;
        }

        if (isStop && isDecelerate)
        {
            isDecelerate = false;
            isStop = false;
        }
    }
}
