using UnityEngine;
using UnityEngine.InputSystem;

public class GameInitializer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] PlayerControl player;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 50f;

    [Space]
    [Header("Camera")]
    [SerializeField] CameraFollow cam;
    [SerializeField] private float decal = -3;

    [Space]
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

    [Space]
    [Header("Map")]
    [SerializeField] GameObject playground;
    [SerializeField] GameObject obstacles;

    private void CreateObject()
    {
        player = Instantiate(player);
        cam = Instantiate(cam);
        gameManager = Instantiate(gameManager);
        Instantiate(playground);
        Instantiate(obstacles);
    }

    private void Initialize()
    {
        player.Initialize(actions, speed, jumpForce);
        player.gameObject.SetActive(true);

        cam.Initialize(player, decal, speed);
        cam.gameObject.SetActive(true);

        gameManager.Initialize(player, cam);
        gameManager.gameObject.SetActive(true);
    }

    void Start()
    {
        CreateObject();
        Initialize();
    }
}
