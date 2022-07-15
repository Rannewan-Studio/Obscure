using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 PlayerVelocity;
    [SerializeField] private float _gravityValue;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _moveSpeed;
    private CharacterController _characterController;
    private PlayerInput _playerInput;
    private bool _isGrounded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Fall();
        Move();
        Jump();
        Stoop();
    }

    private void Move()
    {
        Vector2 moveInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        _characterController.Move(moveDirection * Time.deltaTime * _moveSpeed);

        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void Jump()
    {
        if(_playerInput.actions["Jump"].triggered && _isGrounded)
        {
            PlayerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        PlayerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(PlayerVelocity * Time.deltaTime);
    }

    private void Fall()
    {
        _isGrounded = _characterController.isGrounded;
        if(_isGrounded && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }
    }

    private void Stoop()
    {
        if(_playerInput.actions["Stoop"].ReadValue<float>() == 0)
        {
            // Временная реализация функции приседа, в будущем можно будет подключить анимацию и уменьшение коллайдера.
            Vector3 playerScale = transform.localScale;
            playerScale.y = 1f;
            transform.localScale = playerScale;
        }
        else if(_playerInput.actions["Stoop"].ReadValue<float>() > 0 && _isGrounded)
        {
            Vector3 playerScale = transform.localScale;
            playerScale.y = 0.75f;
            transform.localScale = playerScale;
        }
    }
}