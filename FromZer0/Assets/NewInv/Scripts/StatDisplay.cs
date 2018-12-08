using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using fz.CharacterStats;

public class StatDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] Text nameText;
    [SerializeField] Text valueText;
    [SerializeField] StatToolTip tooltip;

    private CharacterStat _stat;
    public CharacterStat Stat {
        get { return _stat; }
        set
        {
            _stat = value;
            UpdateStatValue();
        }
    }

    private string _name;
        public string Name {

            get { return _name;  }

            set
            {
                _name = value;
                nameText.text = _name;
            }
        }

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        nameText = texts[0];
        valueText = texts[1];

        if (tooltip == null)
            tooltip = FindObjectOfType<StatToolTip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowToolTip(Stat, Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }

    public void UpdateStatValue()
    {
        valueText.text = _stat.Value.ToString();
    }
}
