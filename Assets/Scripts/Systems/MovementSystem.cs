using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovebleComponent, DirectionComponent> _movableFilter = null;

    public void Run()
    {
        foreach (var i in _movableFilter)
        {
            ref var modelComponent = ref _movableFilter.Get1(i);
            ref var movebleComponent = ref _movableFilter.Get2(i);
            ref var directionComponent = ref _movableFilter.Get3(i);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.ModelTransform;
            ref var characterControlle = ref movebleComponent.CharacterController;
            ref var speed = ref movebleComponent.Speed;

            Vector3 rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);

            characterControlle.Move(speed * Time.deltaTime * rawDirection);
        }
    }
}
