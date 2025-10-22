using UnityEngine;

public class Beyblade3DBuilder : MonoBehaviour
{
    public Transform attackSlot;
    public Transform defenseSlot;
    public Transform speedSlot;

    private void Start()
    {
        var stats = PlayerBeyData.Instance.beybladeStats;

        if (stats.equippedParts.attackPart != null)
        {
            Instantiate(stats.equippedParts.attackPart.modelPrefab, attackSlot);
        }

        if (stats.equippedParts.defensePart != null)
        {
            Instantiate(stats.equippedParts.defensePart.modelPrefab, defenseSlot);
        }

        if (stats.equippedParts.speedPart != null)
        {
            Instantiate(stats.equippedParts.speedPart.modelPrefab, speedSlot);
        }

        Debug.Log("Ataque: " + stats.CurrentAttack +
                  " | Defensa: " + stats.CurrentDefense +
                  " | Velocidad: " + stats.CurrentSpeed);
    }
}
