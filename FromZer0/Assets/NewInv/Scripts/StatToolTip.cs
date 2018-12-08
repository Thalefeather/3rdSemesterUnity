using UnityEngine;
using UnityEngine.UI;
using System.Text;
using fz.CharacterStats;

public class StatToolTip : MonoBehaviour
{

    [SerializeField] Text StatNameText;
    [SerializeField] Text StatModifiersLabelText;
    [SerializeField] Text StatModifiersText;

    private StringBuilder sb = new StringBuilder();

    public void ShowToolTip(CharacterStat stat, string statName)
    {
        StatNameText.text = GetStatTopText(stat, statName);
        StatModifiersText.text = GetStatModifiersText(stat);

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    private string GetStatTopText(CharacterStat stat, string statName)
    {
        sb.Length = 0;
        sb.Append(statName);
        sb.Append(" ");
        sb.Append(stat.Value);
        sb.Append(" (");
        sb.Append(stat.BaseValue);

        if (stat.Value > stat.BaseValue)
            sb.Append("+");

        sb.Append(stat.Value - stat.BaseValue);
        sb.ToString();
        return sb.ToString();
    }

    private string GetStatModifiersText(CharacterStat stat)
    {
        sb.Length = 0;

        foreach(StatModifier mod in stat.StatModifiers)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (mod.Value > 0)
                sb.AppendLine();

            sb.Append(mod.Value);

            EquippableItem item = mod.Source as EquippableItem;

            if (item != null)
            {
                sb.Append(" ");
                sb.Append(item.ItemName);
            }
            else
            {
                Debug.LogError("Mod is not as EI");
            }
        }
        return sb.ToString();
    }

}
