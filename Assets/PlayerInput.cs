using DefaultNamespace;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : LRMovement.IPlayerActions
{
    private LRMovement playerControls;
    private SimpleMovement isGrounded;
    [SerializeField] private PlayerModsSO PlayerMSO;

    public PlayerInput()
    {
        
        playerControls = new LRMovement();
        playerControls.Player.SetCallbacks(this);
        playerControls.Player.Enable();
    }

    public event Action<Vector2> OnMovementPerformed;
    public event Action OnJumpPerformed;

    public void OnMovement(InputAction.CallbackContext context)
    {
        OnMovementPerformed?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
       
       if (!context.started) return;
       OnJumpPerformed?.Invoke();
        
    }
}
