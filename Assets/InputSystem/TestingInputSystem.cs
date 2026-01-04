using UnityEngine;
using UnityEngine.InputSystem;


public class TestInputSystem : MonoBehaviour
{
    Rigidbody _playerRigidbody;
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        // Allows for only the Player action map to be enabled
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    { 
        // Only executes when it detects the space bar in the action map
        if (!context.performed) return;
        Debug.Log("Jump " + context.phase);
        // Adds force to rigid body to allow jumping
        // Impulse is the type of force
        _playerRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);

    }
}
