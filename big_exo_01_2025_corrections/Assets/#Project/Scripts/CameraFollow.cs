using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerControl player;
    private float decal = -3;
    private float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(PlayerControl player, float decal, float speed)
    {
        this.player = player;
        this.speed = speed;
        this.decal = decal;
    }

    // Update is called once per frame
    public void Process()
    {

        Vector3 goalPosition = transform.position;
        goalPosition.z = player.transform.position.z + decal;

        Vector3 direction = (goalPosition - transform.position).normalized;

        transform.position += Time.deltaTime * speed * direction;


    }
}
