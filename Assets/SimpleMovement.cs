using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private PlayerModsSO PlayerMSO;

        
        
        private Rigidbody rb;
        private PlayerInput input;
        private Vector2 movement;
        public bool IsGrounded;

        Ray ray;
        [SerializeField] private GameObject GroundCheck;
        
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            input = new PlayerInput();
            IsGrounded = true;

            input.OnMovementPerformed += OnMovementPerformed;
            input.OnJumpPerformed += OnJumpPerformed;
        }

        private void Update()
        {
            transform.position += new Vector3(movement.x, 0, 0) * (Time.deltaTime * PlayerMSO.movementSpeed);
            OnGroundCheck();
            
        }

        private void OnDestroy()
        {
            input.OnMovementPerformed -= OnMovementPerformed;
            input.OnJumpPerformed -= OnJumpPerformed;
        }

        private void OnMovementPerformed(Vector2 value)
        {
            movement = value;
        }

        private void OnJumpPerformed()
        {
            rb.AddForce(Vector3.up * PlayerMSO.JumpForce, ForceMode.Impulse);
        }

        private void OnGroundCheck()
        {
            ray = new Ray(GroundCheck.transform.position, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit, 0.6f))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    IsGrounded = true;
                    Debug.Log(IsGrounded);
                }
                else
                {
                    IsGrounded = false;
                    Debug.Log(IsGrounded);
                }

            }
        }
    }
}