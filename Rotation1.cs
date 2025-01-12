using UnityEngine;
public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    void Update()
    {        // Вращение объекта по оси X
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
}
