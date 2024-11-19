using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckOutbounds : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    public LayerMask whatIsOutbounds;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (_player.CanShot)
            {
                if (_player.ballPoints.Count <= 1) return;

                _player.ballPoints.Remove(_player.ballPoints[^1]);
                _player.transform.position = _player.ballPoints[^1];
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Outbounds"))
        {
            if(_player.ballPoints.Count < 1) return;

            _player.transform.position = _player.ballPoints[^1];
            _player.RigidCompo.velocity = Vector2.zero;
        }
    }
}
