using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [Space]

    [SerializeField] GameObject player;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerControl playerControl;
    // [SerializeField] InputActionAsset actions;

    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float lateralSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    [Header("Camera")]
    [Space]

    [SerializeField] GameObject playerCamera;
    [SerializeField] CameraMovement cameraMovement;
    [SerializeField] float cameraDistance = 10f;

    [Header("Plane")]
    [Space]

    [SerializeField] GameObject plane;

    void Start()
    {
        ObjectCreation();
        ObjectInitialization();
    }

    void ObjectCreation()
    {
        playerMovement = Instantiate(playerMovement);
        cameraMovement = Instantiate(cameraMovement);
    }

    void ObjectInitialization()
    {
        playerMovement.Initialize(player, playerControl, forwardSpeed, lateralSpeed, jumpSpeed);
        cameraMovement.Initialize(playerCamera, player, cameraDistance);
    }
}