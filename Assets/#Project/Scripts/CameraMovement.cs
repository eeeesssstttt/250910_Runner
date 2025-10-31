using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerControl player;
    private float cameraDistance = -3;
    private float speed = 10;

    public void Initialize(PlayerControl player, float cameraDistance, float speed)
    {
        this.player = player;
        this.cameraDistance = cameraDistance;
        this.speed = speed;
    }

    private void Move()
    {
        Vector3 destination = transform.position;
        destination.z = player.transform.position.z + cameraDistance;

        Vector3 direction = (destination - transform.position).normalized;

        transform.position += Time.deltaTime * speed * direction;
    }

    public void Process()
    {
        Move();
    }
}
