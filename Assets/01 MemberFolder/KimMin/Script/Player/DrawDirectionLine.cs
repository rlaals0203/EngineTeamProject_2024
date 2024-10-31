using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDirectionLine : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private Transform _cam;

    private LineRenderer _shootDirLine;
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _shootDirLine = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        Vector3 fixedPos = new Vector3
            (_cam.position.x, _player.transform.position.y, _cam.position.z);

        Vector3 shootDir = _player.transform.position - fixedPos;
        Quaternion lookRot = Quaternion.LookRotation(shootDir, Vector3.up);

        _shootDirLine.gameObject.transform.localRotation = Quaternion.Euler(0, lookRot.y, 0);
        Debug.Log(_shootDirLine.gameObject.name);
    }
}
