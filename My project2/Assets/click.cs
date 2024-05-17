using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Проверка клика левой кнопкой мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("You clicked on: " + hit.transform.name);  // Вывод в консоль для отладки
                if (hit.transform.name == "knopka")  // Проверка, что кликнули именно по кнопке
                {
                    hit.transform.Rotate(0, 0, 40);  // Поворот кнопки на 40 градусов
                    Debug.Log("Knopka was clicked and rotated.");
                }
            }
        }
    }
}
