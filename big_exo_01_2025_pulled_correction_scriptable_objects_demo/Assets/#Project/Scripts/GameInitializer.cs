using UnityEngine;
using UnityEngine.InputSystem;

public class GameInitializer : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private GameData gameData;

    [Space]
    [Header("Player")]
    [SerializeField] PlayerControl player;
    [SerializeField] private InputActionAsset actions;

    [Space]
    [Header("Camera")]
    [SerializeField] CameraFollow cam;

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
        player.Initialize(actions, gameData.Player.Speed, gameData.Player.JumpForce);
        player.gameObject.SetActive(true);

        cam.Initialize(player, gameData.Camera.Decal, gameData.Player.Speed);
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
