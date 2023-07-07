
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerModsSO", menuName = "ScriptableObjects/PlayerSO")]
public class PlayerModsSO : ScriptableObject
{
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] public float JumpForce = 3f;
    [SerializeField] public bool IsGrounded;

}
