using UnityEngine;

// Manages player inputs and interactions
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera for raycasting
    public float interactionDistance = 5f; // Maximum distance for interactions

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    // Handles player inputs
    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            InteractWithObject();
        }
    }

    // Cast a ray from the camera to interact with objects
    void InteractWithObject()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null && interactableObject.CanInteract(transform))
            {
                interactableObject.Interact();
            }
        }
    }
}
