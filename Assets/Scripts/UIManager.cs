using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Transform inventoryPanel;
    public GameObject inventoryItemPrefab;
    private List<Item> inventory = new List<Item>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public bool AddItemToInventory(Item item)
    {
        if (inventory.Count >= 20) // Limit inventory size
        {
            Debug.Log("Inventory full");
            return false;
        }
        inventory.Add(item);
        UpdateInventoryDisplay();
        return true;
    }

    public void RemoveItemFromInventory(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            UpdateInventoryDisplay();
        }
    }

    private void UpdateInventoryDisplay()
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory)
        {
            GameObject itemGO = Instantiate(inventoryItemPrefab, inventoryPanel);
            itemGO.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
            itemGO.GetComponentInChildren<Image>().sprite = item.icon;
        }
    }
}
