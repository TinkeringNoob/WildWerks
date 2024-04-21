using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents an interactable object within the game.
public class InteractableObject : MonoBehaviour
{
    public string ItemName;  // Name of the item for identification
    public bool playerInRange;  // Flag to check if the player is within the interaction range

    // Returns the name of the item.
    public string GetItemName()
    {
        return ItemName;
    }

    // Called when another collider enters this object's trigger collider.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the collider belongs to the player
        {
            playerInRange = true;  // Set the flag to true indicating player is in range
        }
    }

    // Called when another collider exits this object's trigger collider.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the collider belongs to the player
        {
            playerInRange = false;  // Set the flag to false indicating player is no longer in range
        }
    }

}
