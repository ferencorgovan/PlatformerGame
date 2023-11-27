using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionPromptText;
    private GameObject interactedObject;
    public void InteractAction(InputAction.CallbackContext context)
    {
        if (context.performed && interactedObject != null)
        {
            InteractWithObject();
        }
    }

    private void InteractWithObject()
    {
        if (interactedObject.TryGetComponent(out IInteractive interactive))
        {
            interactive.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactedObject = collision.gameObject;
            if (interactedObject.TryGetComponent(out IInteractive interactive))
            {
                interactionPromptText.text = interactive.InteractionPrompt();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == interactedObject)
        {
            interactedObject = null;
            interactionPromptText.text = "";
        }
    }
}