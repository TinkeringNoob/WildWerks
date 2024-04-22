using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public float sprintMultiplier = 1.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 lastMove;

    public StaminaSystem staminaSystem;
    public float staminaRecoveryRate = 1f;
    public float staminaDrainRate = 1f;

    void Update()
    {
        lastMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        lastMove = transform.TransformDirection(lastMove);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void FixedUpdate()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isSprinting && staminaSystem.CanUseStamina(staminaDrainRate * Time.fixedDeltaTime) ? speed * sprintMultiplier : speed;

        if (lastMove.magnitude > 0)
        {
            controller.Move(lastMove * currentSpeed * Time.fixedDeltaTime);
        }

        if (isSprinting && lastMove.magnitude > 0 && staminaSystem.CanUseStamina(staminaDrainRate * Time.fixedDeltaTime))
        {
            staminaSystem.UseStamina(staminaDrainRate * Time.fixedDeltaTime);
        }
        else if (!isSprinting)
        {
            staminaSystem.RecoverStamina(staminaRecoveryRate * Time.fixedDeltaTime);
        }

        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
    }
}
