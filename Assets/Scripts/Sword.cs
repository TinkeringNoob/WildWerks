using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage = 25.0f; // Damage inflicted by the sword

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button (attack)
        {
            Attack();
        }
    }

    void Attack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.0f)) // Short range for sword attack
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null && interactableObject.CanInteract())
            {
                interactableObject.Interact();
            }
        }
    }
}
