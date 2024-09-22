using UnityEngine;

public static class Movement 
{
    public static void Forward(float speed, GameObject gameObject)
    {        
        Vector3 newPosition = gameObject.transform.forward * speed * Time.deltaTime;
        gameObject.transform.position += newPosition;
    }
}
