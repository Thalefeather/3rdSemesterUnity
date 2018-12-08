using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Image image;
    [SerializeField] ItemToolTip tooltip;

    public event Action<Item> OnRightClickEvent;

    [SerializeField] private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if(_item == null)
            {
                image.enabled = false;

            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click0");
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("click1");
            if (Item != null)
            {
                Debug.Log("click2");
                OnRightClickEvent(Item);//works in editor, not in build
                
            }
                
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        if(tooltip == null)
        {
            tooltip = FindObjectOfType<ItemToolTip>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Item is EquippableItem)
        {
            tooltip.ShowToolTip((EquippableItem)Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }
}