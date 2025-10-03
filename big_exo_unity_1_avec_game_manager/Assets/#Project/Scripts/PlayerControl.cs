using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayerControl : MonoBehaviour
{
    //public InputActions actions;

    public InputActionAsset actions;
    InputAction xAxis;
    InputAction jump;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jump = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    public float XAxis()
    {
        return xAxis.ReadValue<float>();
    }

    public bool Jump()
    {
        return jump.IsPressed();
    }
}
