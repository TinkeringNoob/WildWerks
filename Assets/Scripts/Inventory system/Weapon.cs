using UnityEngine;

// Inherits from Item
public class Weapon : Item
{
    public float damage;  // Damage the weapon deals

    // Constructor calls base class constructor to set common item properties
    public Weapon(string name, Sprite itemIcon, float weaponDamage) : base(name, itemIcon)
    {
        damage = weaponDamage; // Set specific weapon property
    }
}
