using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefab y Spawns")]
    public GameObject beyPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    [Header("UI")]
    public UIManager uiManager; // Arrástralo desde el inspector

    private GameObject bey1;
    private GameObject bey2;
    private bool gameOver = false;

    void Start()
    {
        // Instanciamos los dos beys
        bey1 = Instantiate(beyPrefab, spawnPoint1.position, Quaternion.identity);
        bey2 = Instantiate(beyPrefab, spawnPoint2.position, Quaternion.identity);

        // Asignamos los targets automáticamente
        BeybladeAI ai1 = bey1.GetComponent<BeybladeAI>();
        BeybladeAI ai2 = bey2.GetComponent<BeybladeAI>();

        ai1.target = bey2;
        ai2.target = bey1;
    }

    // Este método lo va a llamar el script "Beyblade" cuando se quede sin stamina
    public void OnBeyLost(GameObject loser)
    {
        if (gameOver) return; // Evita que se dispare dos veces

        gameOver = true;

        string winner = (loser == bey1) ? "Bey 2" : "Bey 1";
        Debug.Log(winner + " ganó!");

        if (uiManager != null)
            uiManager.ShowWinner(winner);

        // Opcional: podés reiniciar después de unos segundos
        // Invoke("RestartGame", 3f);
    }

    void RestartGame()
    {
        // Destruir los viejos
        Destroy(bey1);
        Destroy(bey2);

        // Reinstanciar
        Start();
        gameOver = false;
    }
}