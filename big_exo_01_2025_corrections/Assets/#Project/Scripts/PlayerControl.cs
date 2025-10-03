using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    private InputActionAsset actions;
    private float speed = 1f;
    private float jumpForce = 50f;

    private Vector3 startPosition;

    private InputAction xAxis;
    private Rigidbody rb;

    private bool canJump = true;

    public void Initialize(InputActionAsset actions, float speed, float jumpForce)
    {
        this.actions = actions;
        this.speed = speed;
        this.jumpForce = jumpForce;

        xAxis = this.actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
        actions.FindActionMap("CubeActionsMap").FindAction("Jump").performed += OnJump;
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
        actions.FindActionMap("CubeActionsMap").FindAction("Jump").performed -= OnJump;
    }

    public void Process()
    {

        MoveX();
        MoveZ();

        if (transform.position.y < startPosition.y - 0.5f)
        {
            Reset();
        }
    }

    private void MoveZ()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;

    }

    private void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (canJump) rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.CompareTag("Goal"))
        {
            enabled = false;
        }
    }
}

