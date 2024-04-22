using UnityEngine;


// Manages stamina operations like consuming and recovering stamina for the player
public class StaminaSystem : MonoBehaviour
{
    public bool CanUseStamina(int amount)
    {
        return playerStats.currentStamina >= amount;
    }
    private PlayerStats playerStats;  // Reference to the PlayerStats component

    void Awake()
    {
        // Get the PlayerStats component from the same GameObject
        playerStats = GetComponent<PlayerStats>();
        if (playerStats == null)
        {
            // Log an error if PlayerStats is not found
            Debug.LogError("StaminaSystem: No PlayerStats component found on this GameObject.");
        }
    }

    // Method to consume stamina; the amount should be positive
    public void UseStamina(int amount)
    {
        if (playerStats.currentStamina >= amount)  // Check if there is enough stamina
        {
            // Reduce the stamina by the specified amount
            playerStats.ModifyStamina(-amount);
            Debug.Log($"Stamina used: {amount}. Remaining stamina: {playerStats.currentStamina}");
        }
        else
        {
            Debug.Log("Not enough stamina.");
        }
    }

    // Method to recover stamina
    public void RecoverStamina(int amount)
    {
        // Increase the stamina by the specified amount
        playerStats.ModifyStamina(amount);
        Debug.Log($"Stamina recovered: {amount}. Current stamina: {playerStats.currentStamina}");
    }
}
