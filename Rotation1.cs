using UnityEngine;
public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    void Update()
    {        // �������� ������� �� ��� X
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
}
