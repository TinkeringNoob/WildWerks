using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera used for raycasting
    public float interactionDistance = 5f; // Maximum distance from which the player can interact with objects

    void Update()
    {
        HandleInput();
    }

    // Handles key inputs for player interactions
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
        if (Input.GetKeyDown(KeyCode.G)) // Key for dropping items
        {
            DropItem();
        }
    }

    // Method to interact with objects
    void InteractWithObject()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null && interactableObject.CanInteract())
            {
                interactableObject.Interact();
            }
        }
    }

    // Method to drop an item
    void DropItem()
    {
        // Implement the logic to drop the item from the inventory
        // This could involve selecting the last item added or allowing the player to select an item to drop
    }
}
