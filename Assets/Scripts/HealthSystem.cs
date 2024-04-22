using UnityEngine;

// Handles health operations such as taking damage and healing for the player
public class HealthSystem : MonoBehaviour
{
    private PlayerStats playerStats;  // Reference to the PlayerStats component

    void Awake()
    {
        // Attempt to get the PlayerStats component from the same GameObject
        playerStats = GetComponent<PlayerStats>();
        if (playerStats == null)
        {
            // If no PlayerStats component is found, log an error message
            Debug.LogError("HealthSystem: No PlayerStats component found on this GameObject.");
        }
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        // Negate the damage value to reduce health
        playerStats.ModifyHealth(-damage);
        Debug.Log($"Damage taken: {damage}. Current health: {playerStats.currentHealth}");
    }

    // Method to heal the player
    public void Heal(int amount)
    {
        // Positive value to increase health
        playerStats.ModifyHealth(amount);
        Debug.Log($"Health healed: {amount}. Current health: {playerStats.currentHealth}");
    }
}
