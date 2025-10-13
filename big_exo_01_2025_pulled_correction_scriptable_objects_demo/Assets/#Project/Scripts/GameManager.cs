using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerControl player;
    private CameraFollow cam;

    public void Initialize(PlayerControl player, CameraFollow cam)
    {
        this.player = player;
        this.cam = cam;
    }

    void Update()
    {
        if (player.enabled) player.Process();
        if (cam.enabled) cam.Process();
    }
}
