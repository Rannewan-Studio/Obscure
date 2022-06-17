using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Interact")) //Проверка на тег предмета с которым можно взаимодействовать
        {
            other.gameObject.GetComponent<Action>().ShowHint(); //Показываем подсказку
            if(Input.GetKey(KeyCode.F)) //Проверка на нажатие кнопки F
                other.gameObject.GetComponent<Action>().OpenMenu(); //Выполнение какой то функции, в данном случаи открыть меню
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Interact"))
        {
            other.gameObject.GetComponent<Action>().HideHint();
        }       
    }
}
//use new input system
//Tag "interact" into String var
//rename "other"
