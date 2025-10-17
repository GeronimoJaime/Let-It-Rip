using UnityEngine;

public class PlayerBeyData : MonoBehaviour
{
    public static PlayerBeyData Instance;

    public BeybladeStats beybladeStats;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
