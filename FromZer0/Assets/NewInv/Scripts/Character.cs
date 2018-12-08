using UnityEngine;
using fz.CharacterStats;


public class Character : MonoBehaviour
{
    public CharacterStat Melee;
    public CharacterStat Ranged;
    public CharacterStat Defense;

    [SerializeField] PInventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel StatPanel;

    private void Awake()
    {
        StatPanel.SetStats(Melee, Defense, Ranged);
        StatPanel.UpdateStatValues();

        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }


    private void EquipFromInventory(Item item)
    {
        if(item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if(item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if(inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    StatPanel.UpdateStatValues();
                }
                item.Equip(this);
                StatPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            StatPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }

}
