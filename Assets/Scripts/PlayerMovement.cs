using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Component for handling character movement physics

    public float speed = 12f;               // Base walking speed
    public float gravity = -9.81f * 2;      // Gravity multiplier for more realistic falling
    public float jumpHeight = 3f;           // How high the player can jump
    public float sprintMultiplier = 1.5f;   // Speed multiplier during sprinting
    public Transform groundCheck;           // Transform used to check if the player is grounded
    public float groundDistance = 0.4f;     // Radius of the ground check sphere
    public LayerMask groundMask;            // Filter to determine what is considered ground

    private Vector3 velocity;               // Current velocity of the player
    private bool isGrounded;                // Is the player currently grounded?
    private Vector3 lastMove;               // Last movement input vector

    public StaminaSystem staminaSystem;     // Reference to the StaminaSystem component for stamina management

    void Update()
    {
        // Process input and update movement direction every frame
        lastMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        lastMove = transform.TransformDirection(lastMove);

        // Check if the player is on the ground using a sphere overlap test
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Reset downward velocity when grounded
        }

        // Handle jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Calculate the velocity required to reach the desired jump height
        }
    }

    void FixedUpdate()
    {
        // Move the player based on input and whether they are sprinting or not
        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) ? speed * sprintMultiplier : speed);
        if (lastMove.magnitude > 0)
        {
            controller.Move(lastMove * currentSpeed * Time.fixedDeltaTime);
            if (Input.GetKey(KeyCode.LeftShift) && staminaSystem.CanUseStamina(1))
            {
                staminaSystem.UseStamina(1);  // Consume stamina when sprinting
            }
        }

        // Always apply gravity to the velocity
        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);  // Apply gravity
    }
}
