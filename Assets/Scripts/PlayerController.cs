using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("GroundCheck")]
    // Центр радиуса в котором должна быть земля.
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundLayer;
    // Радиус в котором должна быть земля, чтобы прыгнуть.
    [SerializeField] private float _groundCheckRadius;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    private Vector3 _moveDirection;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;

    [Header("Other")]
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection.x = context.ReadValue<Vector2>().x;
        _moveDirection.z = context.ReadValue<Vector2>().y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(IsGrounded())
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z); //Задаем прыжок
            }
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_moveDirection.x * _moveSpeed, _rigidbody.velocity.y, _moveDirection.z * _moveSpeed);
        Rotation();
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);
    }

    // Метод поворота.
    private void Rotation()
    {
        // Измерение угла между двумя направлениями.
        if(Vector3.Angle(Vector3.forward, _moveDirection) > 1f || Vector3.Angle(Vector3.forward, _moveDirection) == 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveDirection, _moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}