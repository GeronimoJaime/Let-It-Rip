using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public BeybladeStats beybladeStats;

    public Image attackSlotImage;
    public Image defenseSlotImage;
    public Image speedSlotImage;

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;

    // Actualiza los iconos y stats en la UI
    public void UpdateUI()
    {
        attackSlotImage.sprite = beybladeStats.equippedParts.attackPart != null ?
            beybladeStats.equippedParts.attackPart.icon : null;
        defenseSlotImage.sprite = beybladeStats.equippedParts.defensePart != null ?
            beybladeStats.equippedParts.defensePart.icon : null;
        speedSlotImage.sprite = beybladeStats.equippedParts.speedPart != null ?
            beybladeStats.equippedParts.speedPart.icon : null;

        attackText.text = "Ataque: " + beybladeStats.CurrentAttack;
        defenseText.text = "Defensa: " + beybladeStats.CurrentDefense;
        speedText.text = "Velocidad: " + beybladeStats.CurrentSpeed;
    }

    // Equipar un item desde la UI
    public void EquipItem(Item item)
    {
        beybladeStats.Equip(item);
        UpdateUI();
    }

    // Ir a batalla y guardar stats
    public void GoToBattle()
    {
        PlayerBeyData.Instance.beybladeStats = beybladeStats;
        SceneManager.LoadScene("BattleScene");
    }
}
