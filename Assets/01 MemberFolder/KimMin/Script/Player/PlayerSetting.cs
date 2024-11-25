using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [Header("Setting")]
    public float mass = 0.1f;
    public float drag = 0.1f;
    public float decelerationPoint = 1.0f;
    public float stopPoint = 0.05f;
    public float playerVelocity => RigidCompo.velocity.magnitude;

    public float startDrag => drag;

    public Rigidbody RigidCompo { get; protected set; }
    public PhysicMaterial PhysicsMatCompo { get; protected set; }

    public bool IsRelease { get; set; } = false;
    public bool CanShot { get; set; } = true;
    public bool IsGole { get; set; } = false;
    public bool IsSlope { get; set; } = false;

    public virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody>();
        PhysicsMatCompo = GetComponent<SphereCollider>().material;
        RigidCompo.mass = mass;

        RigidCompo.isKinematic = false;
    }
}
