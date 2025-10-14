using UnityEngine;

public class BeybladeController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject enemigo;

    [Header("Movimiento")]
    public float velocidad = 10f;       // Fuerza base hacia el enemigo
    public float velocidadGiro = 800f;  // Fuerza de giro
    public float empujeMinDist = 2f;    // Distancia mínima antes de separarse
    public float fuerzaSeparacion = 15f;

    [Header("Energía")]
    public float energia = 100f;        // Energía inicial
    public float perdidaEnergia = 5f;   // Cuánto pierde por segundo
    public float velocidadMinima = 2f;  // Velocidad mínima antes de "morir"

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100f; // Para que pueda girar rápido
    }

    void FixedUpdate()
    {
        if (enemigo == null || energia <= 0) return;

        // Reducir energía con el tiempo
        energia -= perdidaEnergia * Time.fixedDeltaTime;
        if (energia <= 0)
        {
            energia = 0;
            return; // Bey queda "inactivo"
        }

        // Dirección hacia el enemigo
        Vector3 direccion = (enemigo.transform.position - transform.position).normalized;

        // Si está muy cerca, aplicar fuerza de separación
        float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
        if (distancia < empujeMinDist)
        {
            Vector3 separacion = (transform.position - enemigo.transform.position).normalized;
            rb.AddForce(separacion * fuerzaSeparacion, ForceMode.Impulse);
        }
        else
        {
            // Empuje hacia el enemigo (solo si hay energía suficiente)
            float fuerza = Mathf.Lerp(velocidadMinima, velocidad, energia / 100f);
            rb.AddForce(direccion * fuerza, ForceMode.Force);
        }

        // Giro constante (depende de energía)
        float giro = Mathf.Lerp(0, velocidadGiro, energia / 100f);
        rb.AddTorque(transform.up * giro, ForceMode.Force);
    }
}
