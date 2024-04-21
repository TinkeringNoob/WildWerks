using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomAI_Movement : MonoBehaviour
{
    public float moveSpeed = 1.0f;  // Movement speed of the AI
    public float rotationSpeed = 120.0f;  // Rotation speed to turn to new directions
    private Animator animator;  // Reference to the Animator component

    private float moveTime;  // How long to move in one direction
    private float waitTime;  // How long to wait before moving again
    private float moveTimer;  // Timer for movement duration
    private float waitTimer;  // Timer for wait duration
    private bool isMoving;  // Flag to check if the AI is currently moving

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to this GameObject
        if (animator == null)  // Check if the Animator component is not found
        {
            Debug.LogError("Animator component missing from this GameObject");  // Log error if Animator is missing
        }

        SetRandomTimers();  // Initialize movement and wait times randomly
        isMoving = true;  // Set the movement flag to true to start moving immediately
        Debug.Log("Movement initialized.");  // Log that movement has been initialized
    }

    void Update()
    {
        if (animator == null) return;  // Exit Update if no Animator component is found

        if (isMoving)  // Check if AI is supposed to be moving
        {
            moveTimer -= Time.deltaTime;  // Decrement the move timer by the elapsed time since last frame
            if (moveTimer > 0)  // Check if there is still time left to move
            {
                animator.SetBool("IsRunning", true);  // Activate the running animation
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);  // Move the object forward
            }
            else  // If move time is up
            {
                isMoving = false;  // Set moving flag to false
                waitTimer = waitTime;  // Reset the wait timer to the initial wait time
                animator.SetBool("IsRunning", false);  // Deactivate the running animation
            }
        }
        else  // If AI is not supposed to be moving
        {
            waitTimer -= Time.deltaTime;  // Decrement the wait timer by the elapsed time since last frame
            if (waitTimer < 0)  // Check if the wait time is over
            {
                isMoving = true;  // Set moving flag to true to start moving
                SetRandomTimers();  // Reinitialize the move and wait times randomly
                RandomizeDirection();  // Change the direction randomly
            }
        }
    }

    private void SetRandomTimers()
    {
        moveTime = Random.Range(2, 5);  // Set the move time to a random value between 2 and 5 seconds
        moveTimer = moveTime;  // Initialize the move timer with the new move time
        waitTime = Random.Range(1, 3);  // Set the wait time to a random value between 1 and 3 seconds
    }

    private void RandomizeDirection()
    {
        float angle = Random.Range(0f, 360f);  // Generate a random angle between 0 and 360 degrees
        transform.rotation = Quaternion.Euler(0, angle, 0);  // Rotate the GameObject to the new random angle
    }
}
