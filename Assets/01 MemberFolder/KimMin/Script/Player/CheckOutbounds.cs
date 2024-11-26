using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckOutbounds : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private BallShooting _ballShooting;
    public LayerMask whatIsOutbounds;

    public void Initialize(Player player)
    {
        _player = player;
        _ballShooting = _player.GetCompo<BallShooting>();
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (_player.CanShot)
            {
                TeleportPrevious(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Outbounds"))
        {
            TeleportPrevious(true);
        }
    }

    private void TeleportPrevious(bool isOut)
    {
        Debug.Log("µ¹¾Æ°¡");
        if (_player.ballPoints.Count <= 1) return;

        //_player.RigidCompo.interpolation = RigidbodyInterpolation.None;

        _player.transform.position = _player.ballPoints[^1];

        //_player.RigidCompo.interpolation = RigidbodyInterpolation.Interpolate;

        if (!isOut)
        {
            _player.ballPoints.Remove(_player.ballPoints[^1]);
            _ballShooting.ballPointCnt -= 1;
        }


        _player.RigidCompo.velocity = Vector2.zero;
    }
}
