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
        _objectPool.Initialize(_enemyPrefab.gameObject);
        TurnOn();
    }

    private IEnumerator SpawnEnemy()
    {
        var timeInterval = new WaitForSeconds(_delay);

        while (_objectPool.TryGetObject(out GameObject enemy))
        {
            yield return timeInterval;

            SetEnemy(enemy, _spawnPoint.position);
        }
    }

    private void SetEnemy(GameObject poolEnemy, Vector3 spawnPoint)
    {
        poolEnemy.SetActive(true);
        poolEnemy.transform.position = spawnPoint;

        if (poolEnemy.TryGetComponent<Enemy>(out Enemy enemy))
            enemy.SetTarget(_target);
    }

    private void TurnOn()
    {
        if (_spawnEnemyWithDelay != null)
        {
            StopCoroutine(_spawnEnemyWithDelay);
        }

        _spawnEnemyWithDelay = StartCoroutine(SpawnEnemy());
    }
}
