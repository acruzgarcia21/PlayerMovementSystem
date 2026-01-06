using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerInputActions = new PlayerInputActions();
    }
    // Better Practice to do OnEnable/OnDisable so double firing doesn't happen in Awake!
    private void OnEnable()
    {
        // Allows for only the Player action map to be enabled
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Jump.performed -= Jump;
        _playerInputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 playerInput = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        float playerSpeed = 6f;

        // This is for more stiff feeling
        // If rolling/floating is more interesting, just change linearVelocity to addForce
        Vector3 desiredSpeed = new Vector3(playerInput.x, 0f, playerInput.y) * playerSpeed;
        Vector3 velocity = _playerRigidbody.linearVelocity;
        
        _playerRigidbody.linearVelocity = new Vector3(desiredSpeed.x, velocity.y, desiredSpeed.z);
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
