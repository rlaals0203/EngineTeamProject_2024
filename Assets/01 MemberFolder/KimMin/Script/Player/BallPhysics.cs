using System;
using System.Collections;
using UnityEngine;

public class BallPhysics : MonoBehaviour, IPlayerComponent
{
    public event Action OnShootEndEvent;

    private Player _player;
    private BallShooting _ballShooting;
    private CheckGole _checkGole;
    private float _decPoint;

    private bool _isSet = false;

    public void Initialize(Player player)
    {
        _player = player;
        _ballShooting = _player.GetCompo<BallShooting>();
        _checkGole = _player.GetCompo<CheckGole>();
    }

    private void Update()
    {
        if (!_player.CanShot)
            FixedDeceleration(); 
    }

    private void FixedDeceleration()
    {
        float playerSpeed = _player.RigidCompo.velocity.magnitude;

        _player.RigidCompo.drag = playerSpeed >= _decPoint ? _player.startDrag : 1.5f;

        if (_player.stopPoint >= playerSpeed)
            TryStopBall();

        if (!_isSet && !_player.CanShot)
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

        if (!_player.IsSlope) StartCoroutine(ShotReadyRoutine());
    }

    private IEnumerator ShotReadyRoutine()
    {
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.1f);

            if (_player.RigidCompo.velocity.magnitude >= _player.stopPoint)
                yield break;
        }

        if (_player.RigidCompo.velocity == Vector3.zero)
        {
            if (_isSet) OnShootEndEvent?.Invoke();

            if (_ballShooting.stroke > 12 && _isSet)
                _checkGole.OnGole(true);

            _isSet = false;
            _player.stateMachine.ChangeState(StateEnum.Idle);
        }
    }
}
