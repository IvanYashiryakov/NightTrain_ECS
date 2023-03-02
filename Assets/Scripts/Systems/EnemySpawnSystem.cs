using Leopotam.Ecs;
using UnityEngine;

public class EnemySpawnSystem : IEcsRunSystem
{
    private readonly EcsFilter<EnemySpawnDataComponent> _enemySpawnFilter = null;

    public void Run()
    {
        foreach (var i in _enemySpawnFilter)
        {
            ref var spawnData = ref _enemySpawnFilter.Get1(i);

            if (spawnData.Enemies.Count >= spawnData.LimitCount)
                continue;

            Vector3 startPosition = Vector3.one;

            if (spawnData.Enemies.Count > 0)
            {
                startPosition = spawnData.Enemies[^1].transform.position * 2;
            }

            spawnData.Enemies.Add(GameObject.Instantiate(spawnData.Prefab));
            spawnData.Enemies[^1].transform.position = startPosition;
        }
    }
}
