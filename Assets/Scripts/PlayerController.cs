using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 8f;
    [SerializeField] private float runSpeed = 12f;
    private void Update()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkingSpeed;
        Vector2 playerInput = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) playerInput.y += 1;
        if (Input.GetKey(KeyCode.A)) playerInput.x -= 1;
        if (Input.GetKey(KeyCode.S)) playerInput.y -= 1;
        if (Input.GetKey(KeyCode.D)) playerInput.x += 1;
        
        playerInput = playerInput.normalized;
        Vector3 moveDirection = new Vector3(playerInput.x, 0, playerInput.y);
        transform.position += moveDirection * (currentSpeed * Time.deltaTime);
        
    }
}
