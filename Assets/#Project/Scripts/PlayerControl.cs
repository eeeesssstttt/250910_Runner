using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.PackageManager.Requests;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    private InputActionAsset actions;
    private string actionMapName;
    private string lateralMovementActionName;
    private string jumpActionName;
    private InputAction xAxis;

    private Rigidbody rb;

    private Vector3 startPosition;

    private float speed = 1f;
    private float jumpMagnitude = 50f;
    private bool canJump = true;

    public void Initialize(InputActionAsset actions, string actionMapName, string lateralMovementActionName, string jumpActionName, float speed, float jumpMagnitude)
    {
        this.actions = actions;
        this.actionMapName = actionMapName;
        this.lateralMovementActionName = lateralMovementActionName;
        this.jumpActionName = jumpActionName;
        this.speed = speed;
        this.jumpMagnitude = jumpMagnitude;

        xAxis = this.actions.FindActionMap(actionMapName).FindAction(lateralMovementActionName);
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        actions.FindActionMap(actionMapName).Enable();
        actions.FindActionMap(actionMapName).FindAction(jumpActionName).performed += OnJump;
    }

    private void OnDisable()
    {
        actions.FindActionMap(actionMapName).Disable();
        actions.FindActionMap(actionMapName).FindAction(jumpActionName).performed -= OnJump;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            enabled = false;
        }
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;
    }

    private void MoveZ()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (canJump) rb.AddForce(jumpMagnitude * Vector3.up, ForceMode.Acceleration);
    }

    private void Reset()
    {
        transform.position = startPosition;
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
}
