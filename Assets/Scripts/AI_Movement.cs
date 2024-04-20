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
        animator = GetComponent<Animator>();  // Get the Animator component attached to the GameObject
        SetRandomTimers();
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer > 0)
            {
                animator.SetBool("IsRunning", true);  // Set the IsRunning boolean to true to play the running animation
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
                waitTimer = waitTime;
                animator.SetBool("IsRunning", false);  // Set the IsRunning boolean to false to stop the running animation
            }
        }
        else
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer < 0)
            {
                isMoving = true;
                SetRandomTimers();
                RandomizeDirection();
            }
        }
    }

    private void SetRandomTimers()
    {
        moveTime = Random.Range(2, 5);  // Randomly between 2 and 5 seconds
        moveTimer = moveTime;
        waitTime = Random.Range(1, 3);  // Randomly between 1 and 3 seconds
    }

    private void RandomizeDirection()
    {
        float angle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
