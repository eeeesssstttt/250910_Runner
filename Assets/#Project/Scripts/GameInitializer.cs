using UnityEngine;
using UnityEngine.InputSystem;

public class GamaInitializer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] PlayerControl player;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private string actionMapName;
    [SerializeField] private string lateralMovementActionName;
    [SerializeField] private string jumpActionName;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpMagnitude = 50f;

    [Space]
    [Header("Camera")]
    [SerializeField] CameraMovement cam;
    [SerializeField] private float cameraDistance = -3;

    [Space]
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

    [Space]
    [Header("Level")]
    [SerializeField] GameObject terrain;
    [SerializeField] GameObject obstacles;

    private void CreateObjects()
    {
        player = Instantiate(player);
        cam = Instantiate(cam);
        gameManager = Instantiate(gameManager);
        Instantiate(terrain);
        Instantiate(obstacles);
    }

    public void InitializeObjects()
    {
        player.Initialize(actions, actionMapName, lateralMovementActionName, jumpActionName, speed, jumpMagnitude);
        player.gameObject.SetActive(true);

        cam.Initialize(player, cameraDistance, speed);
        cam.gameObject.SetActive(true);

        gameManager.Initialize(player, cam);
        gameManager.gameObject.SetActive(true);
    }

    public void Start()
    {
        CreateObjects();
        InitializeObjects();
    }
}