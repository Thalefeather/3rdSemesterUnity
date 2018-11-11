using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] EquipmentSlots;
    GameObject PC;

    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            EquipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }

        PC = GameObject.Find("Player");
    }

    private void OnValidate()
    {
        EquipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if (EquipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)EquipmentSlots[i].Item;
                EquipmentSlots[i].Item = item;

                if(item.DefenseBonus > 0)
                {
                    PC.gameObject.GetComponent<T_SkillTracker>().defenseGear = item.DefenseBonus;
                }
                if(item.MeleeBonus > 0)
                {
                    PC.gameObject.GetComponent<T_SkillTracker>().meleeGear = item.MeleeBonus;
                }
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if (EquipmentSlots[i].Item == item)
            {
                if (item.DefenseBonus > 0)
                {
                    PC.gameObject.GetComponent<T_SkillTracker>().defenseGear -= item.DefenseBonus;
                }
                if (item.MeleeBonus > 0)
                {
                    PC.gameObject.GetComponent<T_SkillTracker>().meleeGear -= item.MeleeBonus;
                }

                EquipmentSlots[i].Item = null;
                
                return true;
            }
        }
        return false;
    }
}
