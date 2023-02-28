using Leopotam.Ecs;
using UnityEngine;

public sealed class MovementSystem : IEcsRunSystem
{
    //private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;

    public void Run()
    {
        foreach (var i in _movableFilter)
        {
            ref var modelComponent = ref _movableFilter.Get1(i);
            ref var movableComponent = ref _movableFilter.Get2(i);
            ref var directionComponent = ref _movableFilter.Get3(i);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.ModelTransform;
            ref var characterController = ref movableComponent.CharacterController;
            ref var speed = ref movableComponent.Speed;

            Vector3 rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);

            //ref var velocity = ref movableComponent.Velocity;
            //velocity.y += movableComponent.Gravity * Time.deltaTime;

            characterController.Move(speed * Time.deltaTime * rawDirection);
            //characterController.Move(velocity * Time.deltaTime);
        }
    }
}
