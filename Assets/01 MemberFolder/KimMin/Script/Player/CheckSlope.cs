using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlope : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    [SerializeField] private float raySize = 0.5f;
    [SerializeField] private float slopeThreshold = 5f;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        RaySlope();
    }

    private void RaySlope()
    {
        RaycastHit hit;
        Vector3 ray = transform.position + Vector3.down * 0.1f;
        if (Physics.Raycast(ray, Vector3.down, out hit, raySize))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);

            if (angle > slopeThreshold)
            {
                _player.IsSlope = true;
                Debug.Log("°æ»ç");
            }
            else
            {
                _player.IsSlope = false;

                _player.RigidCompo.velocity = new Vector3(
                    _player.RigidCompo.velocity.x,
                    _player.RigidCompo.velocity.y / 1.5f,
                    _player.RigidCompo.velocity.z);
            }
        }
    }
}
