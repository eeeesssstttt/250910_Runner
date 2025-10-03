using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    //CORRECTION
    // [SerializeField] PlayerControl player; // alternatively, displays only options with PlayerControl.
    [SerializeField] private float speed = 10;
    [SerializeField] float cameraHeight = 3.5f;
    [SerializeField] float cameraDistance = 10f;

    void Start()
    {
        // // with PlayerControl player, can check if it is null and find an object with that component
        //     if (player == null)
        //     {
        //         player = FindFirstObjectByType<PlayerControl>();
        //     }
        // there's also GetComponentInChildren<>()
        transform.position = player.transform.position + cameraHeight * Vector3.up - cameraDistance * Vector3.forward;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // transform.position = new Vector3(
        //     transform.position[0],
        //     transform.position[1],
        //     player.transform.position[2] - cameraDistance);

        // transform.position += (player.transform.position[2] - transform.position[2] - cameraDistance) * Vector3.forward;

        // CORRECTION 1 (non-optimal, tends to snap forward)

        // Vector3 goalPosition = transform.position;
        // goalPosition.z = player.transform.position.z - cameraDistance;
        // transform.position = goalPosition;

        // CORRECTION 2

        Vector3 goalPosition = transform.position;
        goalPosition.z = player.transform.position.z - cameraDistance;

        Vector3 direction = (goalPosition - transform.position).normalized; // normalize gives you a direction : (destination - départ) normalized gives direction. or direction from a to b is (b - a)normalized.
        transform.position += Time.deltaTime * speed * direction;
        // this means if camera far away it smoothly comes back to correct distance from player.
    }
}
