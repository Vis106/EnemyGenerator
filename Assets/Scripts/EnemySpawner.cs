using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private Transform _target;

    private Coroutine _spawnEnemyWithDelay;          

    private void Start()
    {
        _objectPool.Initialize(_enemyPrefab); 
        TurnOn();
    }

    private IEnumerator Spawning()
    {
        var timeInterval = new WaitForSeconds(_delay);

        while (_objectPool.TryGetObject(out Enemy enemy))
        {
            yield return timeInterval;

            Spawn(enemy, _spawnPoint.position);
        }
    }

    private void Spawn(Enemy poolEnemy, Vector3 spawnPoint)
    {
        poolEnemy.gameObject.SetActive(true);
        poolEnemy.transform.position = spawnPoint;

        if (poolEnemy.TryGetComponent(out Enemy enemy))
            enemy.SetTarget(_target);
    }

    private void TurnOn()
    {
        if (_spawnEnemyWithDelay != null)
        {
            StopCoroutine(_spawnEnemyWithDelay);
        }

        _spawnEnemyWithDelay = StartCoroutine(Spawning());
    }
}
