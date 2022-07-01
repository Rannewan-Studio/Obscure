using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private Transform _rayStartPoint;
    [SerializeField] private float _maxInteractDistance;
    private Interactable _interactable;
    private bool _canInteract;

    private void Update()
    {
        RaycastHit hit;
        _canInteract = Physics.Raycast(_rayStartPoint.position, _rayStartPoint.forward, out hit, _maxInteractDistance, _interactableLayer);

        if(_canInteract)
        {
            _interactable = hit.collider.GetComponent<Interactable>();
            _interactable.Hint.Show();
        }

        if(!_canInteract && _interactable != null)
        {
            _interactable.Hint.Hide();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(_canInteract)
            {
                if(_interactable.LastInteractState == "Positive")
                {
                    _interactable.OnPositiveInteract.Invoke();
                    _interactable.LastInteractState = "Negative";  
                }
                else if(_interactable.LastInteractState == "Negative")
                {
                    _interactable.OnNegativeInteract.Invoke();
                    _interactable.LastInteractState = "Positive";
                }
            }
        }
    }
}