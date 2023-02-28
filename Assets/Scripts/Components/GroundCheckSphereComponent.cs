using System;
using UnityEngine;

[Serializable]
public struct GroundCheckSphereComponent
{
    public LayerMask GroundMask;
    public Transform GroundCheckSphere;
    public float GroundDistance;
    public bool IsGrounded;
}
