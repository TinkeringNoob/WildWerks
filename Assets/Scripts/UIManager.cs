using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;  // Displays status messages to the player
    public Slider healthSlider;         // UI slider to display player's health
    public Slider staminaSlider;        // UI slider to display player's stamina

    public HealthSystem healthSystem;   // Reference to the HealthSystem component
    public StaminaSystem staminaSystem; // Reference to the StaminaSystem component

    void Start()
    {
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
        if (healthSystem)
        {
            UpdateHealthBar();  // Update the health bar based on player's current health
        }
        if (staminaSystem)
        {
            UpdateStaminaBar();  // Update the stamina bar based on player's current stamina
        }
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = healthSystem.currentHealth;
        healthSlider.maxValue = healthSystem.maxHealth;
    }

    private void UpdateStaminaBar()
    {
        staminaSlider.value = staminaSystem.currentStamina;
        staminaSlider.maxValue = staminaSystem.maxStamina;
    }
}
