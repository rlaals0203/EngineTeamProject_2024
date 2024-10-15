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
        FixedDeceleration();
    }

    private void FixedDeceleration()
    {
        if (!_player.IsShot || _player.IsIdle) return;

        Vector3 velocity = _player.RigidCompo.velocity;
        float currentVelo = Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y);

        Debug.Log(currentVelo);

        if (currentVelo <= _player.decelerationPoint && !isDecelerate)
        {
            Debug.Log("급감");
            _player.RigidCompo.drag = 2f;
            isDecelerate = true;
        }
        else if(currentVelo <= _player.stopPoint && !isStop)
        {
            Debug.Log("정지");
            _player.RigidCompo.velocity = Vector3.zero;
            _player.RigidCompo.drag = _player.drag;
            isStop = true;
        }

        if (isStop && isDecelerate)
        {
            Debug.Log("초기화");
            isDecelerate = false;
            isStop = false;
        }
    }
}
