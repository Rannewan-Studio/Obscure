using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private LayerMask _climbLayer;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _maxClimbDistance;
    [SerializeField] private float _climbSpeed;
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private bool _canClimb;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Climb();
    }

    private void Climb()
    {
        RaycastHit hit;
        _canClimb = Physics.Raycast(_rayPoint.position, -_rayPoint.forward, out hit, _maxClimbDistance, _climbLayer);

        Vector2 climbInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        if(_canClimb && climbInput != Vector2.zero)
        {
            // _playerMovement.PlayerVelocity.y = Mathf.Sqrt(_climbSpeed * 51);
            _playerMovement.PlayerVelocity.y = _climbSpeed;
        }
    }
}
