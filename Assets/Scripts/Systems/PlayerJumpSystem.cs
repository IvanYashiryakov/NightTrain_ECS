using UnityEngine;
using Leopotam.Ecs;

public class PlayerJumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent, JumpComponent, JumpEvent> _jumpFilter = null;

    public void Run()
    {
        foreach (var i in _jumpFilter)
        {
            ref var entity = ref _jumpFilter.GetEntity(i);
            ref var groundCheck = ref _jumpFilter.Get2(i);
            ref var jumpComponent = ref _jumpFilter.Get3(i);
            ref var movable = ref entity.Get<GravityComponent>();
            ref var velocity = ref movable.Velocity;

            if (groundCheck.IsGrounded == false)
                continue;

            velocity.y = Mathf.Sqrt(jumpComponent.Force * -2f * movable.Gravity);
        }
    }
}
