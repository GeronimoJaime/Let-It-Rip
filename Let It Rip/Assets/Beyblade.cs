using UnityEngine;
using UnityEngine.UI;

public class Beyblade : MonoBehaviour
{
    [Header("Stats")]
    public float spinForce = 1000f;       // Fuerza inicial de giro
    public float stamina = 100f;          // Energía de la Bey
    public float staminaLossRate = 5f;    // Cuánto baja por segundo

    [Header("Identificación")]
    public int beyID;                     // 1 o 2
    public float maxStamina = 100f;       // Stamina máxima

    [Header("UI")]
    public Slider staminaBar;             // Barra de stamina en la interfaz
    private UIManager uiManager;          // Referencia al UIManager

    [Header("Efectos")]
    public GameObject collisionEffect;    // Partículas al chocar

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100f;
        rb.AddTorque(Vector3.up * spinForce);

        // Inicializar barra de stamina si existe
        if (staminaBar != null)
            staminaBar.value = 1f;

        // Inicializar maxStamina si no está seteado
        if (maxStamina <= 0f)
            maxStamina = stamina;
    }

    void Update()
    {
        // Bajar stamina con el tiempo
        stamina -= staminaLossRate * Time.deltaTime;

        // Actualizar barra
        if (staminaBar != null)
            staminaBar.value = stamina / maxStamina;

        // Buscar UIManager si no está asignado
        if (uiManager == null)
            uiManager = Object.FindFirstObjectByType<UIManager>();

        // Actualizar UIManager con la stamina actual
        if (uiManager != null)
            uiManager.SetStamina(beyID, stamina, maxStamina);

        // Si se acabó la stamina → notificar derrota
        if (stamina <= 0)
        {
            stamina = 0;
            rb.angularVelocity = Vector3.zero;

            // Avisar al GameManager
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
                gm.OnBeyLost(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Cada choque hace perder stamina
        stamina -= 10f;

        // Partículas en el punto de impacto
        if (collisionEffect != null && other.contacts.Length > 0)
            Instantiate(collisionEffect, other.contacts[0].point, Quaternion.identity);
    }
}
