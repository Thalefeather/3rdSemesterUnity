
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Weapon,
    Gun,
    Accessory1,
    Accessory2,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int MeleeBonus;
    public int RangeBonus;
    public int DefenseBonus;
    [Space]
    public float MeleePercentBonus;
    public float RangePercentBonus;
    public float DefensePercentBonus;
    [Space]
    public EquipmentType EquipmentType;
	
}
