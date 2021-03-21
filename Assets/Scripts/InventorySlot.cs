using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Inspector editable fields
    public InventorySlotVar selectedInventorySlotVar;
    public GameEvent selectionChangedEvent;
    public GameObject itemPrefab;
    public Image image;
    
    // Runtime fields
    public Item Item { get; private set; }

    private void OnMouseDown()
    {
        selectedInventorySlotVar.Slot = this;
        selectionChangedEvent.Raise();
    }

    public void PutNewItem()
    {
        RemoveItem();
        Item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Item>();
        Item.transform.localPosition = Vector3.zero;
    }
    
    public void RemoveItem()
    {
        if (Item != null)
        {
            Destroy(Item.gameObject);
            Item = null;
        }
    }
}
