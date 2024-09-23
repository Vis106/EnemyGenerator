using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector3 _offset;

    private Transform _target;

    private void Update()
    {
        EnemyMovement.Move(_speed, this, _target, _offset);
    }       

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
