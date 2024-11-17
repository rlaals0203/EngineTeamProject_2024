using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutbounds : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    public LayerMask whatIsOutbounds;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Outbounds"))
        {
            _player.transform.position = _player.ballPoints[^1];
            _player.RigidCompo.velocity = Vector2.zero;
        }
    }
}
