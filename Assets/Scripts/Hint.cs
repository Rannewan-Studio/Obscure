using UnityEngine;
using TMPro;

public class Hint : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    public void Show()
    {
        _text.enabled = true;
    }

    public void Hide()
    {
        _text.enabled = false;
    }
}
