using UnityEngine;
using Leopotam.Ecs;

sealed class PlayerJumpSendEventSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, JumpComponent> _playerFilter = null;

    public void Run()
    {
        if (Input.GetKeyDown(KeyCode.Space) != true)
            return;

        foreach (var i in _playerFilter)
        {
            ref var entity = ref _playerFilter.GetEntity(i);
            entity.Get<JumpEvent>();
        }
    }
}
