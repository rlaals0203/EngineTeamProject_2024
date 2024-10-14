using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [Header("Setting")]
    public float mass;
    public float drag;

    public Rigidbody RigidCompo { get; private set; }

    public bool IsIdle { get; set; }
    public bool IsGoled { get; set; }

}
