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

        if (_player.IsSlope)
        {
            _player.PhysicsMatCompo.bounciness = 0;
        }
        else
        {
            if (_player.RigidCompo == null || !_player.IsLoaded) return;

            Vector3 veloctiy = _player.RigidCompo.velocity;
            veloctiy.y = Mathf.Clamp(_player.RigidCompo.velocity.y, int.MinValue, 0); ;
            _player.RigidCompo.velocity = veloctiy;
            _player.PhysicsMatCompo.bounciness = 0.7f;
        }
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
