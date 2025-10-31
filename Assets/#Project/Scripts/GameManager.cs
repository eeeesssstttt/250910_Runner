using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerControl player;
    private CameraMovement cam;

    public void Initialize(PlayerControl player, CameraMovement cam)
    {
        this.player = player;
        this.cam = cam;
    }

    private void Update()
    {
        if (player.enabled) player.Process();
        if (cam.enabled) cam.Process();
    }
}