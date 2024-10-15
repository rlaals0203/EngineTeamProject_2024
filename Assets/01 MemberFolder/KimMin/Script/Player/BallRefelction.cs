using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRefelction : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private Ray _ray;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
/*        _ray = new Ray(_player.transform.position, 
            _player.RigidCompo.velocity.normalized); */
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
