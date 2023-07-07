using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private LRMovement input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody rb = null;
    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private float JumpForce;
    

    private void Awake()
    {
        input = new LRMovement();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementPerformed;
        input.Player.Jump.started += OnJumpInputClicked;
        
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementPerformed;
        input.Player.Jump.started -= OnJumpInputClicked;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        velocity.x = moveVector.x * MovementSpeed * Time.fixedDeltaTime * 100f;

        rb.velocity = velocity;

    }

    

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        Debug.Log($"state: {value.phase}. moveVector: {moveVector}");
    }

    

    private void OnJumpInputClicked(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }
}
