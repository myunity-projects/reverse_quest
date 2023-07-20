using UnityEngine;

public class EnemySpawnPointMover : SpawnPointMover
{
    private float _distanceToAtack = 10;

    private Transform _allySpawnPoint;

    private void Start()
    {
        _allySpawnPoint = GameObject.Find("AllySpawnPoint").transform;
    }

    protected override void Update()
    {
        if (Enemy.onEnemyAttacked == null && Vector3.Distance(transform.position, _allySpawnPoint.position) <= _distanceToAtack)
        {
            base.Update();
        }
    }
}
