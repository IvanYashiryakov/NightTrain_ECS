using UnityEngine;
using Leopotam.Ecs;

sealed class CursorLockSystem : IEcsInitSystem
{
    public void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
