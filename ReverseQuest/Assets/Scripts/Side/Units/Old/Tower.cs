using UnityEngine;

public class Tower : Unit
{
    private Transform _allySpawnPoint;
    private GameObject _core;

    private void OnEnable()
    {
        _core = Resources.Load("Other/Core") as GameObject;
        _allySpawnPoint = GameObject.Find("AllySpawnPoint").transform;
        Attack();
    }

    public override void Attack()
    {
        foreach (Transform ally in _allySpawnPoint)
        {
            GameObject core = Instantiate(_core, transform.position, Quaternion.identity);
            core.transform.LookAt(ally);
        }
        base.Attack();
    }

    private void OnDestroy()
    {
        Ally.onAllyAttacked -= GetDamage;
    }
}
