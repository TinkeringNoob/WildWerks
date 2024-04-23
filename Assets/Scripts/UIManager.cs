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
    public Button toggleInventoryButton;  // Button to toggle the inventory display

    void Start()
    {
        // Initialize inventory display to be hidden
        inventoryPanel.gameObject.SetActive(false); // Hide inventory panel at start

        // Attach toggleInventory method to the button's onClick event
        toggleInventoryButton.onClick.AddListener(ToggleInventory);

        // Check if essential components are assigned
        if (!healthSystem)
        {
            Debug.LogError("UIManager: HealthSystem reference not set.");
        }
        if (!staminaSystem)
        {
            Debug.LogError("UIManager: StaminaSystem reference not set.");
        }
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

        // Check if the 'I' key is pressed to toggle the inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
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

    // Toggles the visibility of the inventory panel
    public void ToggleInventory()
    {
        inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
    }
}
