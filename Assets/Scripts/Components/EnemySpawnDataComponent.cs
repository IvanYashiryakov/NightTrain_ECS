using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public struct EnemySpawnDataComponent
{
    public GameObject Prefab;
    public int LimitCount;
    [HideInInspector] public List<GameObject> Enemies;
}
