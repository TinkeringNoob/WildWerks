using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Component for handling movement physics

    public float speed = 12f;              // Base walking speed
    public float gravity = -9.81f * 2;     // Gravity effect, intensified for a more realistic feel
    public float jumpHeight = 3f;          // How high the player can jump
    public float sprintMultiplier = 1.5f;  // Speed multiplier during sprinting
    public Transform groundCheck;          // Position marker for checking if the player is grounded
    public float groundDistance = 0.4f;    // Distance for the ground check
    public LayerMask groundMask;           // Layers considered as ground

    private Vector3 velocity;              // Current velocity vector of the player
    private bool isGrounded;               // Flag indicating if the player is on the ground
    private Vector3 move;                  // Movement direction vector
    private bool isSprinting;              // Flag for sprinting state

    public StaminaSystem staminaSystem;    // Reference to the StaminaSystem component
    private float nextStaminaTime = 0;     // Time control for the next stamina update

    void Update()
    {
        // Handle non-physics input here
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Reset the downward velocity when grounded
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;

        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Jump handling
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Calculate the velocity needed to reach the jump height
        }
    }

    void FixedUpdate()
    {
        // Handle all physics-based movement here
        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;
        if (isSprinting)
        {
            TryToSprint(currentSpeed);
        }
        else
        {
            controller.Move(move * currentSpeed * Time.fixedDeltaTime);  // Move at normal speed
            TryToRecoverStamina();
        }

        // Apply gravity in all cases
        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    // Attempts to sprint, consuming stamina
    void TryToSprint(float currentSpeed)
    {
        if (Time.time >= nextStaminaTime && staminaSystem.CanUseStamina(1))
        {
            nextStaminaTime = Time.time + 0.1f;  // Manage stamina usage every 0.1 seconds
            staminaSystem.UseStamina(1);        // Consume stamina
            controller.Move(move * currentSpeed * Time.fixedDeltaTime);  // Apply sprinting speed
        }
    }

    // Recovers stamina while walking
    void TryToRecoverStamina()
    {
        if (Time.time >= nextStaminaTime && move != Vector3.zero)
        {
            nextStaminaTime = Time.time + 0.5f;  // Manage stamina recovery every 0.5 seconds
            staminaSystem.RecoverStamina(1);     // Recover stamina
        }
    }
}
