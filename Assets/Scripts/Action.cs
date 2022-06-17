using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private GameObject _menu; //Объект меню
    [SerializeField] private GameObject _hint; //Подсказка

    //Метод открытия меню
    public void OpenMenu()
    {
        _menu.SetActive(true); //Показать меню
    }

    //Меню показа подсказки
    public void ShowHint()
    {
        _hint.SetActive(true); //Покозать подсказку
    }

    //Меню скрытия подсказки
    public void HideHint()
    {
        _hint.SetActive(false); //Скрыть подсказку
    }
}
