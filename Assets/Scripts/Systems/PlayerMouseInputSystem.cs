using UnityEngine;
using Leopotam.Ecs;

sealed class PlayerMouseInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> _playerFilter = null;

    private float _axisX;
    private float _axisY;

    public void Run()
    {
        GetAxis();
        ClampAxis();

        foreach (var i in _playerFilter)
        {
            ref var mouseLookDirectionComponent = ref _playerFilter.Get2(i);

            mouseLookDirectionComponent.Direction.x = _axisX;
            mouseLookDirectionComponent.Direction.y = _axisY;
        }
    }

    private void GetAxis()
    {
        _axisX += Input.GetAxis("Mouse X");
        _axisY -= Input.GetAxis("Mouse Y");
    }

    private void ClampAxis()
    {
        _axisY = Mathf.Clamp(_axisY, -86, 75);
    }
}
