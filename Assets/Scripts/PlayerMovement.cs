using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Reference to the CharacterController component

    public float speed = 12f;               // Normal walking speed
    public float gravity = -9.81f * 2;      // Gravity effect on the player, multiplied to make it feel more realistic
    public float jumpHeight = 3f;           // Height the player can jump
    public float sprintMultiplier = 1.5f;   // Multiplier to increase speed when sprinting

    public Transform groundCheck;           // Transform at the player's feet to determine if they are on the ground
    public float groundDistance = 0.4f;     // Radius of the ground check sphere
    public LayerMask groundMask;            // LayerMask to filter what is considered ground

    Vector3 velocity;                       // Current velocity of the player
    bool isGrounded;                        // Is the player currently grounded

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground using a sphere overlap test
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If grounded and velocity is downward, reset Y velocity to a small negative value
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input from horizontal and vertical axes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction vector based on input
        Vector3 move = transform.right * x + transform.forward * z;

        // Check for sprint input and apply speed multiplier if sprinting
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // Move the player using the character controller
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Check for jump input and apply jump velocity if grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity to velocity
        velocity.y += gravity * Time.deltaTime;

        // Move the player using the character controller for vertical movement
        controller.Move(velocity * Time.deltaTime);
    }
}
