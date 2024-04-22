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
            if (hit.collider.gameObject.GetComponent<InteractableObject>()
                && hit.collider.gameObject.GetComponent<InteractableObject>().Type == InteractableType.Rabbit)
            {
                // Call the interact function on the rabbit
                hit.collider.gameObject.GetComponent<InteractableObject>().Interact();
            }
        }
    }
}
