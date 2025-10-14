using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bey1;
    public Transform bey2;
    public Vector3 offset = new Vector3(0, 10, -10);

    void LateUpdate()
    {
        if (bey1 == null || bey2 == null) return;

        // Punto medio entre los dos
        Vector3 midpoint = (bey1.position + bey2.position) / 2f;

        // Distancia entre ellos para alejar la cámara
        float distance = Vector3.Distance(bey1.position, bey2.position);

        // Posición de la cámara
        transform.position = midpoint + offset - new Vector3(0, 0, distance * 0.3f);
        transform.LookAt(midpoint);
    }
}
