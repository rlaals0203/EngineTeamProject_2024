using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [Header("Setting")]
    public float shootPower = 500f;
    public float mass = 0.1f;
    public float drag = 1f;

    public Rigidbody RigidCompo { get; set; }

    public bool IsIdle { get; set; } = false;
    public bool IsGoled { get; set; } = false;
}
