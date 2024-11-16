using System;
using System.Collections;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    public event Action OnShootEndEvent;

    private Player _player;
    private float _decPoint;

    private bool _isSet = false;

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
        float playerSpeed = _player.RigidCompo.velocity.magnitude;

        _player.RigidCompo.drag = playerSpeed >= _decPoint ? _player.startDrag : 1.5f;

        if (_player.stopPoint >= playerSpeed)
            TryStopBall();

        if (!_isSet && !_player.canShot)
            InitializeDeceleration(playerSpeed);
    }

    private void InitializeDeceleration(float speed)
    {
        _decPoint = speed / 5;
        _isSet = true;
    }

    private void TryStopBall()
    {
        _player.RigidCompo.velocity = Vector3.zero;
        _player.RigidCompo.drag = _player.startDrag;

        StartCoroutine(ShotReadyRoutine());
    }

    private IEnumerator ShotReadyRoutine()
    {
        yield return new WaitForSeconds(1f);

        if (_player.RigidCompo.velocity.magnitude <= _player.stopPoint)
        {
            _player.stateMachine.ChangeState(StateEnum.Idle);

            if(_isSet)
                OnShootEndEvent?.Invoke();

            _isSet = false;
        }
    }
}
