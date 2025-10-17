using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Beyblade/Item")]
public class Item : ScriptableObject
{
    public string itemName;          // Nombre de la pieza
    public Sprite icon;              // Icono que se mostrará en el inventario 2D
    public GameObject modelPrefab;   // Prefab 3D que se instanciará en batalla
    public int attackBonus;          // Bonus de ataque
    public int defenseBonus;         // Bonus de defensa
    public int speedBonus;           // Bonus de velocidad

    public ItemType type;            // Tipo de pieza (ataque, defensa o velocidad)

    // Enum para diferenciar los tipos de piezas
    public enum ItemType
    {
        AttackPart,
        DefensePart,
        SpeedPart
    }
}
