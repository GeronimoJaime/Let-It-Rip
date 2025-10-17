using UnityEngine;

[System.Serializable]
public class EquippedParts
{
    public Item attackPart;
    public Item defensePart;
    public Item speedPart;
}

public class BeybladeStats : MonoBehaviour
{
    public int baseAttack = 10;
    public int baseDefense = 10;
    public int baseSpeed = 10;

    public EquippedParts equippedParts = new EquippedParts();

    public int CurrentAttack
    {
        get
        {
            int bonus = 0;
            if (equippedParts.attackPart != null) bonus += equippedParts.attackPart.attackBonus;
            if (equippedParts.defensePart != null) bonus += equippedParts.defensePart.attackBonus;
            if (equippedParts.speedPart != null) bonus += equippedParts.speedPart.attackBonus;
            return baseAttack + bonus;
        }
    }

    public int CurrentDefense
    {
        get
        {
            int bonus = 0;
            if (equippedParts.attackPart != null) bonus += equippedParts.attackPart.defenseBonus;
            if (equippedParts.defensePart != null) bonus += equippedParts.defensePart.defenseBonus;
            if (equippedParts.speedPart != null) bonus += equippedParts.speedPart.defenseBonus;
            return baseDefense + bonus;
        }
    }

    public int CurrentSpeed
    {
        get
        {
            int bonus = 0;
            if (equippedParts.attackPart != null) bonus += equippedParts.attackPart.speedBonus;
            if (equippedParts.defensePart != null) bonus += equippedParts.defensePart.speedBonus;
            if (equippedParts.speedPart != null) bonus += equippedParts.speedPart.speedBonus;
            return baseSpeed + bonus;
        }
    }

    public void Equip(Item item)
    {
        if (item == null) return;

        switch (item.type)
        {
            case Item.ItemType.AttackPart:
                equippedParts.attackPart = item;
                break;
            case Item.ItemType.DefensePart:
                equippedParts.defensePart = item;
                break;
            case Item.ItemType.SpeedPart:
                equippedParts.speedPart = item;
                break;
        }
    }

    public void Unequip(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.AttackPart:
                equippedParts.attackPart = null;
                break;
            case Item.ItemType.DefensePart:
                equippedParts.defensePart = null;
                break;
            case Item.ItemType.SpeedPart:
                equippedParts.speedPart = null;
                break;
        }
    }
}
