using UnityEngine;
using fz.CharacterStats;

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
    Skill1,
    Skill2,
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
    public bool Heal;
    public bool Laser;
    public int Cooldown1;
    public int Cooldown2;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(Character c)
    {
        if(MeleeBonus != 0)
            c.Melee.AddModifier(new StatModifier(MeleeBonus, StatModType.Flat, this));
        if (RangeBonus != 0)
            c.Ranged.AddModifier(new StatModifier(RangeBonus, StatModType.Flat, this));
        if (DefenseBonus != 0)
            c.Defense.AddModifier(new StatModifier(DefenseBonus, StatModType.Flat, this));

        if (MeleePercentBonus != 0)
            c.Melee.AddModifier(new StatModifier(MeleePercentBonus, StatModType.PercentMult, this));
        if (RangePercentBonus != 0)
            c.Ranged.AddModifier(new StatModifier(RangePercentBonus, StatModType.PercentMult, this));
        if (DefensePercentBonus != 0)
            c.Defense.AddModifier(new StatModifier(DefensePercentBonus, StatModType.PercentMult, this));

    }

    public void Unequip(Character c)
    {
        c.Melee.RemoveAllModifiersFromSource(this);
        c.Ranged.RemoveAllModifiersFromSource(this);
        c.Defense.RemoveAllModifiersFromSource(this);
    }

}
