using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private ObjectPool _objectPool;

    private Coroutine _spawnEnemyWithDelay;
    private float _maxAngle = 361;
    private float _minAngle = 0;

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
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Debug.Log(spawnPointNumber);

            yield return timeInterval;

            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.transform.Rotate(0.0f, GetRandomAngle(), 0.0f);
    }

    private void TurnOn()
    {
        if (_spawnEnemyWithDelay != null)
        {
            StopCoroutine(_spawnEnemyWithDelay);
        }

        _spawnEnemyWithDelay = StartCoroutine(SpawnEnemy());
    }

    private float GetRandomAngle()
    {
        return Random.Range(_minAngle, _maxAngle);
    }
}
