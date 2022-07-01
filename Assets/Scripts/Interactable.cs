using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // Выполнение положительного действия
    public UnityEvent OnPositiveInteract;
    // Выполнение отрицательного действия
    public UnityEvent OnNegativeInteract;
    public Hint Hint;
    // Состояние последнего взаимодействия
    [HideInInspector] public string LastInteractState = "Negative";
}
