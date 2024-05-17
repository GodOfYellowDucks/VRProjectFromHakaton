using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject knopka;
    public GameObject spindel;
    private bool isOn = false;
    private Quaternion offRotation;
    private Quaternion onRotation;
    private float rotationSpeed = 5f;  // �������� �������� ������
    private float spindleSpeed = 1500f;  // ������������ �������� �������� �������� (����/���)
    private float currentSpindleSpeed = 0f;  // ������� �������� �������� ��������
    private float acceleration = 100f;  // ��������� �������� (����/���^2)

    private void Start()
    {
        offRotation = Quaternion.Euler(0, 0, 0);
        onRotation = Quaternion.Euler(0, 0, -73);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == knopka)
                {
                    isOn = !isOn;  // ������������ ��������� ������
                }
            }
        }

        if (isOn)
        {
            knopka.transform.localRotation = Quaternion.Lerp(knopka.transform.localRotation, onRotation, Time.deltaTime * rotationSpeed);
            // ������� ���������� �������� �������� ��������
            currentSpindleSpeed = Mathf.Lerp(currentSpindleSpeed, spindleSpeed, Time.deltaTime * acceleration);
            spindel.transform.Rotate(currentSpindleSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            knopka.transform.localRotation = Quaternion.Lerp(knopka.transform.localRotation, offRotation, Time.deltaTime * rotationSpeed);
            // ������� ���������� �������� �������� �������� ��� ����������
            currentSpindleSpeed = Mathf.Lerp(currentSpindleSpeed, 0, Time.deltaTime * acceleration);
            spindel.transform.Rotate(currentSpindleSpeed * Time.deltaTime, 0, 0);
        }
    }
}
