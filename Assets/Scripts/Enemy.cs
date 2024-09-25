using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector3 _offset;

    private Transform _target;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.LookAt(_target.position);
        transform.position = Vector3.MoveTowards(transform.position, _target.position + _offset, _speed * Time.deltaTime);
    }
}
