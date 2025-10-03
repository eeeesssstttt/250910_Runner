using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

// check repo for correction branches

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerControl : MonoBehaviour
{
    const float PLAYER_SIZE = 1f;

    //public InputActions actions;

    [SerializeField] InputActionAsset actions;
    private InputAction xAxis;
    private float xMove = 0;
    public float lateralVelocity = 10f;

    // private Collider collider;
    // private float groundColliderHeight = 0.025f;
    private float groundColliderHeight = 0.6f;
    private Vector3 boxCenter;
    private Vector3 boxHalfExtents;
    private float maxDistance;
    [SerializeField] GameObject groundPlane;
    private float ground;
    private bool isGrounded = true;
    public float jumpVelocity = 10f;
    public float jumpDuration = 0.5f;

    // CORRECTION

    private Rigidbody rb;
    [SerializeField] private float jumpAcceleration = 500f;
    private bool canJump = true;
    private Vector3 startPosition;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        // collider = GetComponent<Collider>();

        // CORRECTION
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
        // CORRECTION
        actions.FindActionMap("CubeActionsMap").FindAction("Jump").performed += OnJump;
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
        // CORRECTION
        actions.FindActionMap("CubeActionsMap").FindAction("Jump").performed -= OnJump;

    }

    // void Start()
    // {
    //     ground = groundPlane.transform.position[1];
    //     boxCenter = collider.bounds.center; // = (0, 0.5, -3)
    //     boxHalfExtents = collider.bounds.extents; // = (0.5, 0.5, 0.5)
    //     boxHalfExtents.y = groundColliderHeight; // = (0.5, 0.025, 0.5)
    //     maxDistance = 0.2f;
    //     // maxDistance = boxHalfExtents.y; // = 0.025
    // }

    void Update()
    {
        MoveX();
        // MoveY();
        // GroundCheck();
        if (transform.position.y < startPosition.y - 0.5f)
        {
            Reset();
        }
    }

    void MoveX()
    {
        if (isGrounded) { xMove = xAxis.ReadValue<float>(); }
        transform.position += lateralVelocity * Time.deltaTime * xMove * transform.right;
        // set vector at end to reduce computation.
    }

    // void MoveY()
    // // was called OnJump() in correction
    // {

    //     jump.performed += ctx => StartCoroutine(Jump());
    // }


    // MoveZ() would have been here, which I wrote in a different script called ForwardMovement.

    IEnumerator Jump()
    {
        float timeElapsed = 0f;

        if (!isGrounded) { yield break; }
        while (timeElapsed < jumpDuration)
        {
            timeElapsed += Time.deltaTime;
            transform.position += jumpVelocity * Time.deltaTime * transform.up;
            yield return null;
        }
    }

    void GroundCheck()
    {
        if (transform.position[1] > ground + PLAYER_SIZE / 2 - 0.01
        && transform.position[1] < ground + PLAYER_SIZE / 2 + 0.01)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Debug.Log((Physics.OverlapBox(
        //     transform.position,
        //     Vector3.one * PLAYER_SIZE / 2,
        //     Quaternion.identity)).Length);

        // Debug.Log(Physics.BoxCast(
        //     boxCenter,
        //     boxHalfExtents,
        //     Vector3.down, Quaternion.identity,
        //     maxDistance));

        // at some point, will set up boxcast to properly detect ground.
    }
    // CORRECTION
    private void OnJump(InputAction.CallbackContext callbackContext)
    // = callback function referred to in OnEnable()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpAcceleration, ForceMode.Acceleration);
        }
    }

    private void Reset()
    {
        transform.position = startPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            canJump = true;
        }
        else if (collision.collider.CompareTag("Obstacle"))
        {
            Reset();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Goal"))
    //     {
    //         enabled = false; // disables player controller.
    //     }
    // }
}
