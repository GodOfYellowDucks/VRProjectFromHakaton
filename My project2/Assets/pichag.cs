using UnityEngine;

public class GearShiftRotation : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float[] angles = { 0, -35, -58, -76 };  // Углы Z для каждой передачи
    private float closestAngle;

    void Start()
    {
        mainCamera = Camera.main;  // Получение ссылки на главную камеру
    }

    void OnMouseDown()
    {
        screenPoint = mainCamera.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(cursorPoint) + offset;

        // Рассчитываем угол вращения на основе позиции курсора
        Vector3 direction = cursorPosition - transform.position;
        float angleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Ограничиваем вращение только по оси Z
        transform.rotation = Quaternion.Euler(0, 0, angleZ);
    }

    void OnMouseUp()
    {
        // При отпускании мыши фиксируем ближайший угол
        float currentAngle = transform.eulerAngles.z;
        float minDistance = Mathf.Infinity;
        foreach (float angle in angles)
        {
            float distance = Mathf.Abs(Mathf.DeltaAngle(currentAngle, angle));
            if (distance < minDistance)
            {
                minDistance = distance;
                closestAngle = angle;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, closestAngle);
    }
}
