using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Item item;  // Reference to the Item ScriptableObject for this object

    // Public method to be called when interaction is needed
    public void Interact()
    {
        if (UIManager.Instance.AddItemToInventory(item)) // Attempt to add the item to the inventory
        {
            Debug.Log(item.itemName + " added to inventory.");
            Destroy(gameObject); // Remove the object from the game world
        }
    }

    // Example method to return the item's name if needed elsewhere
    public string GetItemName()
    {
        return item.itemName;
    }

    // Public method to check if interaction is possible (e.g., item is not null)
    public bool CanInteract()
    {
        return item != null;
    }

    // Generate interaction message
    public string InteractionMessage()
    {
        return "Press E to interact with " + item.itemName;
    }
}
