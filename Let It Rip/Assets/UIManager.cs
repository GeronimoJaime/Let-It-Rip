using UnityEngine;
using UnityEngine.UI;
using TMPro; // si usas TextMeshPro

public class UIManager : MonoBehaviour
{
    [Header("Sliders de Stamina")]
    public Slider sliderBey1;
    public Slider sliderBey2;

    [Header("Texto de Ganador")]
    public TextMeshProUGUI winnerText; // si usas TMP
    // public Text winnerText; // si usas UI normal

    public void SetStamina(int beyID, float stamina, float maxStamina)
    {
        float value = stamina / maxStamina;

        if (beyID == 1 && sliderBey1 != null)
            sliderBey1.value = value;
        else if (beyID == 2 && sliderBey2 != null)
            sliderBey2.value = value;
    }

    public void ShowWinner(string winnerName)
    {
        if (winnerText != null)
        {
            winnerText.text = winnerName + " ganó!";
        }
    }
}
