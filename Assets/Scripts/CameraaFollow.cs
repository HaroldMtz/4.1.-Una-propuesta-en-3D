using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0,6,-8);
    public float followLerp = 10f;

    float fixedY;

    void Start(){ fixedY = transform.position.y; }

    void LateUpdate()
    {
        if (!target) return;
        // Sigue X y Z del jugador; mantiene Y fija
        Vector3 desired = target.position + offset;
        desired.y = fixedY;
        transform.position = Vector3.Lerp(transform.position, desired, Time.deltaTime * followLerp);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
