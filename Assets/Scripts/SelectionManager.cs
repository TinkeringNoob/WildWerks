using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Include TMPro namespace for using TextMeshPro components

public class SelectionManager : MonoBehaviour
{
    // Public GameObject for the UI panel that displays interaction information
    public GameObject interaction_Info_UI;
    // Variable to store the TextMeshProUGUI component where interaction text will be displayed
    TextMeshProUGUI interaction_text;

    private void Start()
    {
        // Ensure that the interaction_Info_UI GameObject is assigned to avoid runtime errors
        if (!interaction_Info_UI)
        {
            Debug.LogError("Interaction Info UI GameObject is not assigned in the inspector");
            this.enabled = false;  // Disable script if no UI component assigned
            return;
        }

        // Retrieve the TextMeshProUGUI component from the interaction_Info_UI GameObject
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();

        // Check if the interaction_text was successfully retrieved
        if (!interaction_text)
        {
            Debug.LogError("The TextMeshProUGUI component is not found on the interaction_Info_UI GameObject");
            this.enabled = false;  // Disable script if component is missing
        }

        // Initially disable the interaction UI until it's needed
        interaction_Info_UI.SetActive(false);
    }

    void Update()
    {
        // Create a ray from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform a raycast; if it hits something within 10 units
        if (Physics.Raycast(ray, out hit, 10))
        {
            // Get the Transform component of the object that was hit
            Transform selectionTransform = hit.transform;

            // Check if the object hit has an InteractableObject component
            InteractableObject interactableObject = selectionTransform.GetComponent<InteractableObject>();
            if (interactableObject)
            {
                // If it does, update the interaction text to the item's name and make the UI visible
                interaction_text.text = interactableObject.GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                // If no InteractableObject is found, hide the interaction UI
                interaction_Info_UI.SetActive(false);
            }
        }
        else
        {
            // If the raycast doesn't hit anything, also ensure the interaction UI is not visible
            interaction_Info_UI.SetActive(false);
        }
    }
}
