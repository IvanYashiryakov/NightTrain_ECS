using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

    private float _moveX;
    private float _moveZ;

    public void Run()
    {
        SetDirection();

        foreach (var i in _directionFilter)
        {
            ref var directionComponent = ref _directionFilter.Get2(i);
            ref var direction = ref directionComponent.Direction;

            direction.x = _moveX;
            direction.z = _moveZ;
        }
    }

    private void SetDirection()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }
}
