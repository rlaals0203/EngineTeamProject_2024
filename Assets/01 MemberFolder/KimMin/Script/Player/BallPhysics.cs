using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    public event Action OnShootEndEvent;

    private Player _player;
    private float _decelerationPoint;
    private float playerSpeed;

    private bool _isSet = false;
    private bool _isDecelerate = false;
    private bool _isStop = false;

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
        playerSpeed = _player.RigidCompo.velocity.magnitude;

        if (_isDecelerate && playerSpeed >= _decelerationPoint)
        {
            _player.RigidCompo.drag = _player.startDrag;
            _isDecelerate = false;
        }
        else if (playerSpeed <= _decelerationPoint && !_isDecelerate)
        {
            _player.RigidCompo.drag = 1.5f;
            _isDecelerate = true;
        }
        else if (playerSpeed <= _player.stopPoint && !_isStop)
        {
            if (_isStop) return;
            StopBall();
        }
    }

    private void LateUpdate()
    {
        if (!_isSet && !_player.canShot)
            InitializeDeceleration(playerSpeed);
    }

    private void InitializeDeceleration(float speed)
    {
        _decelerationPoint = speed / 10;
        _isSet = true;
    }

    private void StopBall()
    {
        _player.RigidCompo.velocity = Vector3.zero;
        _player.RigidCompo.drag = _player.startDrag;

        _isStop = true;
        _isSet = false;

        StartCoroutine(ShotReadyRoutine());

        Debug.Log("c");
    }

    private IEnumerator ShotReadyRoutine()
    {
        if (!_isStop || !_isDecelerate) yield return null;

        yield return new WaitForSeconds(1f);

        if (_player.RigidCompo.velocity == Vector3.zero)
        {
            _player.stateMachine.ChangeState(StateEnum.Idle);
            _isDecelerate = false;
            _isStop = false;

            OnShootEndEvent?.Invoke();
        }
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        _player.RigidCompo.velocity = new Vector3(_player.RigidCompo.velocity.x, 0f, 
                _player.RigidCompo.velocity.z);
    }*/
}
