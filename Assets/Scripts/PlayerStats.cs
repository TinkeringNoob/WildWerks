using UnityEngine;

// Manages the player's statistical data such as health and stamina
public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health the player can have
    public int currentHealth { get; private set; }  // Current health, private set to restrict external modification

    public int maxStamina = 100;  // Maximum stamina the player can have
    public int currentStamina { get; private set; }  // Current stamina, private set

    void Start()
    {
        // Initialize current health and stamina to their maximum values at start
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    // Modifies health; accepts positive values for healing and negative for damage
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Clamp health within valid bounds
        if (currentHealth <= 0)
        {
            Die();  // Trigger death if health drops to zero or below
        }
    }

    // Modifies stamina; similar to ModifyHealth method
    public void ModifyStamina(int amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);  // Clamp stamina within valid bounds
    }

    // Handles the player's death
    private void Die()
    {
        Debug.Log("Player has died.");  // Log death, could trigger animations or game over effects
    }
}
