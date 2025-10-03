using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<PlayerRespawn>(out PlayerRespawn playerRespawn);
        if (playerRespawn != null)
        {
            playerRespawn.Respawn();
        }
    }
}
