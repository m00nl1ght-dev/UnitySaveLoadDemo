using System;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemSlotVar selectedItemSlotVar;
    public GameEvent selectionChangedEvent;
    
    public Image Image { get; private set; }

    private void Awake()
    {
        Image = gameObject.GetComponent<Image>();
    }

    private void OnMouseDown()
    {
        selectedItemSlotVar.Slot = this;
        selectionChangedEvent.Raise();
    }
}
