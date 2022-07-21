using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private PlayerInteractor _playerInteractor;
    public UnityEvent OnPositiveInteract;
    public UnityEvent OnNegativeInteract;
    public Hint Hint;
    [HideInInspector] public enum InteractState {Negative, Positive}
    public InteractState LastInteractState = InteractState.Negative;

    private void Start()
    {
        _playerInteractor = FindObjectOfType<PlayerInteractor>();
    }

    private void OnMouseDown()
    {
        if(_playerInteractor.InteractableObject != null)
        {
            _playerInteractor.InteractableObject.Hint.Hide();
        }
        _playerInteractor.InteractableObject = this;
        _playerInteractor.CanInteract = true;
        Hint.Show();
    }
}
