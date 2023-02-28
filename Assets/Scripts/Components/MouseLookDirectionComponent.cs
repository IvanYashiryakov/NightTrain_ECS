using System;
using UnityEngine;

[Serializable]
public struct MouseLookDirectionComponent
{
    public Transform CameraTransform;
    [HideInInspector] public Vector2 Direction;
    [Range(0, 2)] public float MouseSensitivity;
}
