using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;    // Maximum health
    public float currentHealth;       // Current health level

    void Start()
    {
        currentHealth = maxHealth;    // Initialize health to max at start
    }

    // Method to reduce health
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't drop below zero
        if (currentHealth == 0)
        {
            Debug.Log("Player has died.");  // Placeholder for any death logic
        }
    }

    // Method to recover health
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health doesn't exceed max
    }
}
