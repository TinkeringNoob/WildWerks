using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class RandomAI_Movement : MonoBehaviour
{
    // Movement speed of the AI
    public float moveSpeed = 1.0f;

    // Rotation speed to turn to new directions
    public float rotationSpeed = 120.0f;

    // Reference to the Animator component
    private Animator animator;

    // How long to move in one direction
    private float moveTime;

    // How long to wait before moving again
    private float waitTime;

    // Timer for movement duration
    private float moveTimer;

    // Timer for wait duration
    private float waitTimer;

    // Flag to check if the AI is currently moving
    private bool isMoving;

    // Flag to check if the AI is currently waiting
    private bool isWaiting;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Set random timers for movement and waiting
        SetRandomTimers();

        // Start moving
        isMoving = true;
    }

    void Update()
    {
        // If the AI is moving
        if (isMoving)
        {
            // Decrease the move timer
            moveTimer -= Time.deltaTime;

            // If the move timer is greater than 0
            if (moveTimer > 0)
            {
                // Set the IsRunning boolean to true to play the running animation
                animator.SetBool("IsRunning", true);

                // Move the AI forward
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Stop moving
                isMoving = false;

                // Set the wait timer
                waitTimer = waitTime;

                // Set the IsRunning boolean to false to stop the running animation
                animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            // Decrease the wait timer
            waitTimer -= Time.deltaTime;

            // If the wait timer is less than 0
            if (waitTimer < 0)
            {
                // Start moving again
                isMoving = true;

                // Set random timers for movement and waiting
                SetRandomTimers();

                // Randomize the direction
                RandomizeDirection();
            }
        }
    }

    // Set random timers for movement and waiting
    private void SetRandomTimers()
    {
        // Randomly set the move time between 2 and 5 seconds
        moveTime = Random.Range(2, 5);

        // Set the move timer
        moveTimer = moveTime;

        // Randomly set the wait time between 1 and 3 seconds
        waitTime = Random.Range(1, 3);
    }

    // Randomize the direction
    private void RandomizeDirection()
    {
        // Randomly set the angle between 0 and 360 degrees
        float angle = Random.Range(0f, 360f);

        // Set the rotation of the AI
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    // New features:
    // Patrol route radius
    public float patrolRadius = 5.0f;

    // Patrol route points
    public Transform[] patrolPoints;

    // Current patrol point index
    private int currentPatrolPoint = 0;

    // Patrol route behavior
    void Patrol()
    {
        // If there are patrol points
        if (patrolPoints.Length > 0)
        {
            // Move to the current patrol point
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, moveSpeed * Time.deltaTime);

            // If the AI has reached the current patrol point
            if (Vector3.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 1.0f)
            {
                // Move to the next patrol point
                currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
            }
        }
    }

    // Wandering behavior
    void Wander()
    {
        // Randomly set the angle between 0 and 360 degrees
        float angle = Random.Range(0f, 360f);

        // Set the direction
        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;

        // Move in the random direction within the patrol radius
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction * patrolRadius, moveSpeed * Time.deltaTime);
    }
}
