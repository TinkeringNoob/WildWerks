using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Manages all UI-related elements and updates, including player stats and status messages
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;  // Displays status messages to the player
    public Slider healthSlider;         // UI slider to display player's health
    public Slider staminaSlider;        // UI slider to display player's stamina
    public PlayerStats playerStats;     // Reference to the PlayerStats component

    // Start is called before the first frame update
    void Start()
    {
        if (playerStats == null)
        {
            Debug.LogError("UIManager: PlayerStats reference not set.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats != null)
        {
            UpdateHealthBar();   // Update the health bar based on player's current health
            UpdateStaminaBar();  // Update the stamina bar based on player's current stamina
        }
    }

    // Updates the health bar UI to reflect the player's current health
    private void UpdateHealthBar()
    {
        healthSlider.value = playerStats.currentHealth;
        healthSlider.maxValue = playerStats.maxHealth;
    }

    // Updates the stamina bar UI to reflect the player's current stamina
    private void UpdateStaminaBar()
    {
        staminaSlider.value = playerStats.currentStamina;
        staminaSlider.maxValue = playerStats.maxStamina;
    }

    // Update the UI with a new status message
    public void UpdateStatusText(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;  // Set the text of statusText to the provided message
        }
    }
}
