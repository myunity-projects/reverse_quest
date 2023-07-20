using UnityEngine;

public class TowerScriptEnabler : MonoBehaviour
{
    private Tower _towerAtackScript;

    private Transform _allySpawnPoint;

    private float _distanceToAtack = 10;

    private void Start()
    {
        _allySpawnPoint = GameObject.Find("AllySpawnPoint").transform;
        _towerAtackScript = transform.GetComponent<Tower>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _allySpawnPoint.position) <= _distanceToAtack)
        {
            _towerAtackScript.enabled = true;
        }
    }
}
