using SO;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Car; // Ссылка на объект игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания
    public Vector3 offset; // Смещение камеры

    void FixedUpdate()
    {
        Vector3 desiredPosition = Car.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}