using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private LRMovement jumpInput = null;
    private Rigidbody rb = null;
    [SerializeField] private float JumpForce;

    private void Awake()
    {
        jumpInput = new LRMovement();
        rb = GetComponent<Rigidbody>();
        jumpInput.Enable();
        
    }
}
