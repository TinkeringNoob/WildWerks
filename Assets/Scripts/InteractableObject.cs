using UnityEngine;

public enum InteractableType
{
    Rock,   // Rocks that can be picked up
    Tree,   // Trees that can be chopped
    Rabbit  // Rabbits that can be inspected or attacked
}

// This class represents an interactable object within the game.
public class InteractableObject : MonoBehaviour
{
    public string ItemName; // Name of the item for identification
    public InteractableType Type; // Type of interactable object

    // Returns the name of the item.
    public string GetItemName()
    {
        return ItemName;
    }

    // Interaction logic based on the type of the object
    public void Interact()
    {
        switch (Type)
        {
            case InteractableType.Rock:
                Debug.Log(ItemName + " was picked up by the player.");
                Destroy(gameObject); // Remove the rock from the game
                break;
            case InteractableType.Tree:
                Debug.Log("Chopping down " + ItemName);
                // Add chopping logic here
                break;
            case InteractableType.Rabbit:
                Debug.Log("Inspecting " + ItemName);
                // Add rabbit interaction logic here
                break;
        }
    }

    // Check if the player is within interaction range
    public bool CanInteract(Transform playerTransform)
    {
        return Vector3.Distance(transform.position, playerTransform.position) <= 5.0f; // Interaction range
    }
}
