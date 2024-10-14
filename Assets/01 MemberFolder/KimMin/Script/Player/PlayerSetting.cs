using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [Header("Setting")]
    public float shootPower = 500f;
    public float mass = 0.1f;
    public float drag = 1f;
    public float decelerationPoint = 1f;
    public float stopPoint = 0.05f;

    public Rigidbody RigidCompo;

    public bool IsIdle { get; set; } = false;
    public bool IsShot { get; set; } = false;

    public virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody>();
        RigidCompo.mass = mass;
        RigidCompo.drag = drag;
    }
}
