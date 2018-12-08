using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ItemToolTip : MonoBehaviour {

    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowToolTip(EquippableItem item)
    {
        ItemNameText.text = item.ItemName;
        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;
        AddStat(item.MeleeBonus, "Strength");
        AddStat(item.RangeBonus, "Range");
        AddStat(item.DefenseBonus, "Defense");

        AddStat(item.MeleePercentBonus, "Strength", isPercent: true);
        AddStat(item.RangePercentBonus, "Range", isPercent: true);
        AddStat(item.DefensePercentBonus, "Defense", isPercent: true);

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName, bool isPercent = false)
    {

        if (value != 0)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            if(value > 0)
            {
                sb.Append("+");
            }

            if (isPercent)
            {
                sb.Append(value*100);
                sb.Append("% ");
            }
            else
            {
                sb.Append(value);
                sb.Append(" ");
            }

            sb.Append(statName);

        }
    }
}
