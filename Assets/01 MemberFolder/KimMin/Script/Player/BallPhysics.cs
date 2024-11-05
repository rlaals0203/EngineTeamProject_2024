using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    public event Action OnShootEndEvent;

    private Player _player;
    private bool isDecelerate = false;
    private bool isStop = false;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (!_player.canShot)
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
            if (isStop) return;
            StopBall();
        }
    }

    private void StopBall()
    {
        _player.RigidCompo.velocity = Vector3.zero;
        _player.RigidCompo.drag = _player.drag;
        isStop = true;

        StartCoroutine(ShotReadyRoutine());
    }

    private IEnumerator ShotReadyRoutine()
    {
        if (!isStop || !isDecelerate) yield return null;

        yield return new WaitForSeconds(1f);

        if (_player.RigidCompo.velocity == Vector3.zero)
        {
            _player.stateMachine.ChangeState(StateEnum.Idle);
            isDecelerate = false;
            isStop = false;

            OnShootEndEvent?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _player.RigidCompo.velocity = new Vector3(_player.RigidCompo.velocity.x, 0f, 
                _player.RigidCompo.velocity.z);
    }

    private void OnCollisionExit(Collision collision)
    {
        _player.RigidCompo.velocity = new Vector3(_player.RigidCompo.velocity.x, 0f,
                _player.RigidCompo.velocity.z);
    }
}
