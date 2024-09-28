using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Container _container;
    [SerializeField] private int _capacity;

    private List<Enemy> _pool = new List<Enemy>();

    public void Initialize(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out Enemy result)
    {
        result = _pool.FirstOrDefault(spawnedObject => spawnedObject.gameObject.activeSelf == false);
        return result != null;
    }
}