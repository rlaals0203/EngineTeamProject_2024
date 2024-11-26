using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [Header("Setting")]
    public float mass = 0.1f;
    public float drag = 0.1f;
    public float decPoint = 1.0f;
    public float stopPoint = 0.05f;

    public float playerVelocity => RigidCompo.velocity.magnitude;
    public float startDrag => drag;

    public Rigidbody RigidCompo { get; protected set; }
    public PhysicMaterial PhysicsMatCompo { get; protected set; }

    public bool IsRelease { get; set; } = false;
    public bool CanShot { get; set; } = true;
    public bool IsGole { get; set; } = false;
    public bool IsSlope { get; set; } = false;
    public bool IsLoaded { get; private set; } = false;

    protected const float MAX_SPEED = 1000f;

    public virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody>();
        PhysicsMatCompo = GetComponent<SphereCollider>().material;
        RigidCompo.mass = mass;

        if (RigidCompo != null)
        {
            RigidCompo.velocity = Vector3.zero;
            RigidCompo.angularVelocity = Vector3.zero;
            IsLoaded = true;
        }

    }
}
