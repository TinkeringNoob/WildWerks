using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    Animator animator; // Reference to the Animator component to control animations

    public float moveSpeed = 0.2f; // Movement speed of the AI

    Vector3 stopPosition; // Position where the AI stops moving

    float walkTime; // Duration the AI walks before stopping
    public float walkCounter; // Counter for the walking duration
    float waitTime; // Duration the AI waits after stopping
    public float waitCounter; // Counter for the waiting duration

    int WalkDirection; // Current walking direction of the AI

    public bool isWalking; // Flag to check if the AI is currently walking

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to the AI

        // Initialize walkTime and waitTime with random values to vary AI behavior
        walkTime = Random.Range(3, 6);
        waitTime = Random.Range(5, 7);

        // Initialize counters with their respective times
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection(); // Initially choose a direction to start walking
    }

    void Update()
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", true); // Activate the running animation

            // Decrease the walkCounter over time
            walkCounter -= Time.deltaTime;

            // Move the AI based on the current WalkDirection
            switch (WalkDirection)
            {
                case 0: // Forward
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 1: // Right
                    transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 2: // Left
                    transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 3: // Backward
                    transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
            }

            // If the walkCounter reaches 0, stop the AI and prepare for waiting
            if (walkCounter <= 0)
            {
                stopPosition = transform.position; // Mark the stopping position
                isWalking = false; // Stop walking
                animator.SetBool("isRunning", false); // Deactivate the running animation
                waitCounter = waitTime; // Reset the waitCounter to the wait time
            }
        }
        else
        {
            // Decrease the waitCounter over time
            waitCounter -= Time.deltaTime;

            // If the waitCounter reaches 0, choose a new direction to walk in
            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }

    // Chooses a random walking direction and resets the walkCounter
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4); // Choose a direction index (0-3)

        isWalking = true; // Start walking
        walkCounter = walkTime; // Reset the walkCounter to the walk time
    }
}