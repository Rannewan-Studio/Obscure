using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckPoint; //Центр радиуса в котором должна быть земля.
    [SerializeField] private LayerMask _groundLayer; //Слой на котором находится земля
    [SerializeField] private float _groundCheckRadius; //Радиус в котором должна быть земля. чтобы прыгнуть
    [SerializeField] private float _moveSpeed; //Скорость передвижения
    [SerializeField] private float _jumpForce; //Сила прыжка
    private Rigidbody _rigidbody;
    private Vector3 _moveVector; //Направление движение

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //Задаем Rigidbody
    }

    private void FixedUpdate()
    {
        Move(); //Вызываем метод передвижения
        Jump(); //Вызываем метод прыжка
    }

    //Метод передвижения
    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal"); //Задаем направление по оси x
        _moveVector.z = Input.GetAxis("Vertical");  //Задаем направление по оси z

        //Задаем движение
        _rigidbody.velocity = new Vector3(_moveVector.x * _moveSpeed, _rigidbody.velocity.y, _moveVector.z * _moveSpeed);
        Rotation();
    }

    //Метод прыжка
    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && IsGrounded()) //Проверка на нажатие кнопки и проверка земли под игроком
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z); //Задаем прыжок
    }

    //Метод проверки на земле ли игрок
    private bool IsGrounded()
    {
        //Проверка на наличие земли под игроком
        //В положительном случае возвращается true
        //В отрицательном случае возвращается false
        return Physics.CheckSphere(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);
    }

    //Метод поворота
    private void Rotation()
    {
        //Измерение угла между двумя направлениями
        if(Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _moveSpeed, 0.0f); //Направление поворота
            transform.rotation = Quaternion.LookRotation(direction); //Задаем поворот
        }
    }
}