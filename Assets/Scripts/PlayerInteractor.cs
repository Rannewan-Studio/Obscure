using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [HideInInspector] public Interactable InteractableObject;
    [HideInInspector] public bool CanInteract;
    [SerializeField] private float _maxInteractDistance;

    private void Update()
    {
        if(InteractableObject != null)
        {
            if(Vector3.Distance(transform.position, InteractableObject.transform.position) >  _maxInteractDistance)
            {
                CanInteract = false;
                InteractableObject.Hint.Hide();
                InteractableObject = null;
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(CanInteract)
            {
                if(InteractableObject.LastInteractState == Interactable.InteractState.Positive)
                {
                    InteractableObject.OnNegativeInteract.Invoke();
                    InteractableObject.LastInteractState = Interactable.InteractState.Negative;  
                }
                else if(InteractableObject.LastInteractState == Interactable.InteractState.Negative)
                {
                    InteractableObject.OnPositiveInteract.Invoke();
                    InteractableObject.LastInteractState = Interactable.InteractState.Positive;
                }
            }
        }
    }
}