using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryPanel;  // Drag the InventoryPanel here in the inspector

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);  // Hide the inventory panel at start
    }

    // Method to toggle the inventory panel visibility
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);  // Toggle the active state
    }
}
