using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject playerCamera;
    private float cameraDistance;

    public void Initialize(GameObject playerCamera, GameObject player, float cameraDistance)
    {
        this.player = player;
        this.playerCamera = playerCamera;
        this.cameraDistance = cameraDistance;

        transform.position = player.transform.position + Vector3.up * cameraHeight - Vector3.forward * cameraDistance;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Vector3.forward * (player.transform.position[2] - transform.position[2] - cameraDistance);

        // playerCamera.transform.position = new Vector3(playerCamera.transform.position[0], playerCamera.transform.position[1], player.transform.position[2] - cameraDistance);
    }
}
