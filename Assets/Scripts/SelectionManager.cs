using System.Collections;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI; // UI panel that displays interaction information
    TextMeshProUGUI interaction_text; // Text component for displaying interaction information

    private GameObject currentInteractable; // Currently detected interactable object

    private void Start()
    {
        // Ensure the UI component is assigned
        if (!interaction_Info_UI)
        {
            Debug.LogError("Interaction Info UI GameObject is not assigned in the inspector");
            this.enabled = false;
            return;
        }

        // Retrieve and check the TextMeshPro component
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
        if (!interaction_text)
        {
            Debug.LogError("TextMeshProUGUI component not found on the interaction_Info_UI GameObject");
            this.enabled = false;
        }

        // Disable the UI initially
        interaction_Info_UI.SetActive(false);
    }

    void Update()
    {
        // Perform a raycast from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) // Adjust distance as needed
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();

            // Check if the object hit has an InteractableObject component and is in range
            if (interactableObject && interactableObject.playerInRange)
            {
                // Set the current interactable if it's within range
                if (currentInteractable != hit.transform.gameObject)
                {
                    currentInteractable = hit.transform.gameObject;
                    interaction_text.text = interactableObject.GetItemName();
                    interaction_Info_UI.SetActive(true);
                }
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

    // Clear the interaction display if no suitable object is detected
    private void ClearInteraction()
    {
        if (currentInteractable != null)
        {
            interaction_Info_UI.SetActive(false);
            currentInteractable = null;
        }
    }
}
