using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public GameObject Menu;
    int open = 0;

    void Start()
    {
        Menu.GetComponent<CanvasGroup>().alpha = 0;
    }

    void OnMouseDown()
    {
        open = (open == 0) ? 1 : 0;
        Menu.GetComponent<CanvasGroup>().alpha = open;
    }
}