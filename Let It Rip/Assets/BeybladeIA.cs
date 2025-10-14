using UnityEngine;

public class BeybladeAI : MonoBehaviour
{
    public bool isEnemy;  // ✅ marcar si este bey es enemigo
    public GameObject target; // el bey al que tiene que perseguir

    public float speed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        // dirección hacia el rival
        Vector3 dir = (target.transform.position - transform.position).normalized;

        // fuerza para ir hacia él
        rb.AddForce(dir * speed);

        // rotación para encarar al enemigo
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime));
    }
}
