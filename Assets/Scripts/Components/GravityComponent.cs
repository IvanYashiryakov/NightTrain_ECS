using System;
using UnityEngine;

[Serializable]
public struct GravityComponent
{
    public float Gravity;
    [HideInInspector] public Vector3 Velocity;
}
