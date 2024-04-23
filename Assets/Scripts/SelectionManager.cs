using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject interactionInfoUI;
    public TextMeshProUGUI interactionText;
    private GameObject currentInteractable;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject && interactableObject.CanInteract())
            {
                SetInteraction(interactableObject);
            }
            else
            {
                ClearInteraction();
            }
        }
        else
        {
            ClearInteraction();
        }
    }

    private void SetInteraction(InteractableObject interactableObject)
    {
        if (currentInteractable != interactableObject.gameObject)
        {
            currentInteractable = interactableObject.gameObject;
            interactionText.text = interactableObject.InteractionMessage(); // Updated to use dynamic message
            interactionInfoUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            interactableObject.Interact();
        }
    }

    private void ClearInteraction()
    {
        if (currentInteractable)
        {
            interactionInfoUI.SetActive(false);
            currentInteractable = null;
        }
    }
}
