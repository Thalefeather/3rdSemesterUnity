using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] Image image;

    public event Action<Item> OnRightClickEvent;

    private Item _item;
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
                OnRightClickEvent(Item);//this doesnt work
                
            }
                
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
}