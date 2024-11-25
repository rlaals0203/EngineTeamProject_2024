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

        if (!_player.IsSlope)
        {
            Vector3 veloctiy = _player.RigidCompo.velocity; veloctiy.y *= 0.5f;
            _player.RigidCompo.velocity = veloctiy;
            Mathf.Clamp(_player.RigidCompo.velocity.y, int.MinValue, 0);
        }
        else Debug.Log("°æ»ç");
    }

    private void RaySlope()
    {
        RaycastHit hit;
        Vector3 ray = transform.position + Vector3.down * 0.1f;
        if (Physics.Raycast(ray, Vector3.down, out hit, raySize))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);

            _player.IsSlope = angle > slopeThreshold;
        }
    }

    private void OnTriggerStay(Collider collide)
    {
        if (collide.CompareTag("NearHole"))
        {
            _player.IsSlope = true;
        }
    }
}
