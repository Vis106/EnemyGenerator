using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        Movement.Forward(_speed, this.gameObject);
    }

    public void SetRotate(float angle)
    {
        transform.Rotate(0.0f, angle, 0.0f);
    }
}
