using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        _animator.SetBool("IsOpen", false);
    }
}
