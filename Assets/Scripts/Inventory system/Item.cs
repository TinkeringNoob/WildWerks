using UnityEngine;

[System.Serializable]  // Make the class visible in the Unity inspector
public class Item
{
    public string itemName; // Name of the item
    public Sprite icon;     // Icon representing the item in the UI

    // Constructor to set item properties
    public Item(string name, Sprite itemIcon)
    {
        itemName = name;
        icon = itemIcon;
    }
}
