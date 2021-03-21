using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // Inspector editable fields
    public ItemSlotVar selectedItemSlotVar;
    public GameEvent selectionChangedEvent;
    public GameObject itemPrefab;
    public Image image;
    
    // Runtime fields
    public Item CurrentItem { get; private set; }

    private void OnMouseDown()
    {
        selectedItemSlotVar.Slot = this;
        selectionChangedEvent.Raise();
    }

    public void PutNewItem()
    {
        RemoveItem();
        CurrentItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Item>();
        CurrentItem.transform.localPosition = Vector3.zero;
    }
    
    public void RemoveItem()
    {
        if (CurrentItem != null)
        {
            Destroy(CurrentItem.gameObject);
            CurrentItem = null;
        }
    }
}
