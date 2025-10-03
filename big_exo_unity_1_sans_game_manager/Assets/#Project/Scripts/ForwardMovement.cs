using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float velocity = 10f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime * transform.forward;
    }
}
