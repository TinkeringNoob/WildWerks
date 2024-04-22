using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI; // UI panel that displays interaction information
    TextMeshProUGUI interaction_text; // Text component for displaying interaction information
    private GameObject currentInteractable; // Currently detected interactable object

    private void Start()
    {
        interaction_Info_UI.SetActive(false); // Initially hide the interaction UI
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
        if (!interaction_text)
        {
            Debug.LogError("TextMeshProUGUI component not found on the interaction_Info_UI GameObject");
            this.enabled = false; // Disable script if component is missing
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cast a ray from the camera to the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) // Raycast to detect interactable objects within 100 units
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();

            if (interactableObject && interactableObject.CanInteract(Camera.main.transform)) // Check if hit object is interactable and in range
            {
                SetInteraction(interactableObject);
            }
            else
            {
                ClearInteraction(); // Clear current interaction if no valid object is hit
            }
        }
        else
        {
            ClearInteraction(); // Clear interaction if raycast hits nothing
        }
    }

    // Setup interaction UI and process interaction
    private void SetInteraction(InteractableObject interactableObject)
    {
        if (currentInteractable != interactableObject.gameObject)
        {
            currentInteractable = interactableObject.gameObject;
            interaction_text.text = interactableObject.GetItemName(); // Display item name
            interaction_Info_UI.SetActive(true); // Show interaction UI
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) // Check for mouse click to interact
        {
            interactableObject.Interact();
        }
    }

    // Clear the interaction display if no suitable object is detected
    private void ClearInteraction()
    {
        if (currentInteractable)
        {
            interaction_Info_UI.SetActive(false); // Hide interaction UI
            currentInteractable = null;
        }
    }
}
