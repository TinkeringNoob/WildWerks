using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    public float maxStamina = 100f;    // Maximum stamina
    public float currentStamina;       // Current stamina level

    void Start()
    {
        currentStamina = maxStamina;   // Initialize stamina to max at start
    }

    // Method to check if there is enough stamina available to perform an action
    public bool CanUseStamina(float amount)
    {
        return currentStamina >= amount; // Check if we have enough stamina
    }

    // Method to use (decrease) the stamina
    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Max(currentStamina, 0); // Ensure stamina doesn't drop below zero
    }

    // Method to recover (increase) stamina
    public void RecoverStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Min(currentStamina, maxStamina); // Ensure stamina doesn't exceed max
    }
}
