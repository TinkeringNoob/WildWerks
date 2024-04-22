using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;  // Required for using List

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;  // Displays status messages to the player
    public Slider healthSlider;         // UI slider to display player's health
    public Slider staminaSlider;        // UI slider to display player's stamina

    public HealthSystem healthSystem;   // Reference to the HealthSystem component
    public StaminaSystem staminaSystem; // Reference to the StaminaSystem component

    public Transform inventoryPanel;    // Panel where inventory items will be displayed
    public GameObject inventoryItemPrefab;  // Prefab for displaying each item in the inventory

    void Start()
    {
        // Check if essential components are assigned
        if (!healthSystem)
        {
            Debug.LogError("UIManager: HealthSystem reference not set.");
        }
        if (!staminaSystem)
        {
            Debug.LogError("UIManager: StaminaSystem reference not set.");
        }

        // Optionally initialize the inventory display here, if needed
    }

    void Update()
    {
        // Update health and stamina bars
        if (healthSystem)
        {
            UpdateHealthBar();
        }
        if (staminaSystem)
        {
            UpdateStaminaBar();
        }
    }

    // Updates the health bar UI to reflect the player's current health
    private void UpdateHealthBar()
    {
        healthSlider.value = healthSystem.currentHealth;
        healthSlider.maxValue = healthSystem.maxHealth;
    }

    // Updates the stamina bar UI to reflect the player's current stamina
    private void UpdateStaminaBar()
    {
        staminaSlider.value = staminaSystem.currentStamina;
        staminaSlider.maxValue = staminaSystem.maxStamina;
    }

    // Method to update the inventory display, to be called when inventory changes
    public void UpdateInventoryDisplay(List<Item> items)
    {
        // Clear existing items in the UI
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Create a new UI item for each item in the inventory
        foreach (Item item in items)
        {
            GameObject itemGO = Instantiate(inventoryItemPrefab, inventoryPanel);
            itemGO.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
            itemGO.GetComponentInChildren<Image>().sprite = item.icon;
        }
    }
}
