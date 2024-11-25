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
                TeleportPrevious(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Outbounds"))
        {
            TeleportPrevious(true);
            Debug.Log("น้");
        }
    }

    private void TeleportPrevious(bool isOut)
    {
        if (_player.ballPoints.Count < 1) return;

        _player.RigidCompo.interpolation = RigidbodyInterpolation.None;

        _player.transform.position = _player.ballPoints[^1];

        if (!isOut) _player.ballPoints.Remove(_player.ballPoints[^1]);

        _player.RigidCompo.velocity = Vector2.zero;
    }
}
