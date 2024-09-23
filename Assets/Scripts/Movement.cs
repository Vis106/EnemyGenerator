using UnityEngine;

public static class EnemyMovement
{
    public static void Move(float speed, Enemy enemy, Transform target, Vector3 offset)
    {
        enemy.transform.LookAt(target.position);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.position, speed * Time.deltaTime);
    }
}
