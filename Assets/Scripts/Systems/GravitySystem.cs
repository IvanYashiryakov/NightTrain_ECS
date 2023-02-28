using Leopotam.Ecs;
using UnityEngine;

public class GravitySystem : IEcsRunSystem
{
    private readonly EcsFilter<GravityComponent, MovableComponent> _gravityFilter = null;

    public void Run()
    {
        foreach (var i in _gravityFilter)
        {
            ref var gravity = ref _gravityFilter.Get1(i);
            ref var movableComponent = ref _gravityFilter.Get2(i);
            ref var characterController = ref movableComponent.CharacterController;

            ref var velocity = ref gravity.Velocity;
            velocity.y += gravity.Gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
