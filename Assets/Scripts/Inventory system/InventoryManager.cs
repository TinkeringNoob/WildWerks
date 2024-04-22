using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // List to store all inventory items

    // Method to add an item to the inventory
    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
    }

    // Method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " removed from inventory.");
        }
    }

    // Method to use an item; specifics would depend on item type
    public void UseItem(Item item)
    {
        if (item is Weapon)
        {
            Debug.Log("Using weapon: " + item.itemName);
            // Additional logic to use the weapon
        }
        // Further conditions can be added for other item types
    }
}
