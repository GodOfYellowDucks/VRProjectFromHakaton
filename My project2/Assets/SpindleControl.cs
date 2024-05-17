using UnityEngine;

public class SpindleControl : MonoBehaviour
{
    public GameObject spindle;
    public GameObject lever;
    public float[] speeds = { 0f, 100f, 200f, 300f };  // Скорости для разных передач
    private int currentGear = 0;  // Текущая передача

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Проверка клика левой кнопкой мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "knopka")  // Проверка, что кликнули именно по кнопке
                {
                    hit.transform.Rotate(0, 0, 40);  // Поворот кнопки на 40 градусов
                    spindle.transform.Rotate(0, 0, speeds[currentGear] * Time.deltaTime);
                }
            }
        }

        // Изменение передачи рычагом
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentGear < speeds.Length - 1)
        {
            currentGear++;
            lever.transform.Rotate(0, 0, -10);  // Поворот рычага при увеличении передачи
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentGear > 0)
        {
            currentGear--;
            lever.transform.Rotate(0, 0, 10);  // Поворот рычага при уменьшении передачи
        }
    }
}
