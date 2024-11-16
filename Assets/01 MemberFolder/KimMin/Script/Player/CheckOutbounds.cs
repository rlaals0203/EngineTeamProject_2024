using UnityEngine;

public class CheckOutbounds : IPlayerComponent
{
    private Player _player;
    public LayerMask whatIsOutbounds;

    public void Initialize(Player player)
    {
        _player = player;

        _player.GetCompo<BallPhysics>().OnShootEndEvent += HandleShootEnd;
    }

    private void HandleShootEnd()
    {
        if (Physics.Raycast(_player.transform.position, Vector3.down, 0.5f, whatIsOutbounds))
        {
            Debug.Log("¾Æ¿ô");
        }
    }
}