using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    // Inspector editable fields
    public ItemDefList itemDefList;
    public Inventory inventory;
    public IntVariable selectedSlotVar;
    public GameEvent selectionChangedEvent;
    public Dropdown defDropdown;
    public Text nameText;
    public Text descriptionText;
    public Slider stackSizeSlider;
    public Text sliderLabelTop;
    public Text sliderLabelLeft;
    public Text sliderLabelRight;

    private void Start()
    {
        // Add all item defs to the dropdown
        var defOptions = new List<Dropdown.OptionData> {new Dropdown.OptionData("Empty")};
        defOptions.AddRange(itemDefList.ItemDefs.Select(d => new Dropdown.OptionData(d.DefId)).ToList());
        defDropdown.options = defOptions;
        OnSelectionChanged();
    }
    
    // Event listener, called when selected item slot changed
    public void OnSelectionChanged()
    {
        // Reset UI to default state
        descriptionText.text = "";
        defDropdown.interactable = true;
        stackSizeSlider.gameObject.SetActive(false);
        stackSizeSlider.value = 1f;
        sliderLabelTop.text = "Not stackable.";

        // First check if any slot is selected
        if (selectedSlotVar.Value >= 0)
        {
            var item = inventory.GetItemInSlot(selectedSlotVar.Value);
            if (item != null && item.Def != null)
            {
                // Slot is not empty, set item texts
                nameText.text = item.Def.ItemName;
                defDropdown.value = itemDefList.ItemDefs.IndexOf(item.Def) + 1;
                descriptionText.text = item.Def.Description;
                if (item.Def.MaxStackSize > 1)
                {
                    // Item is stackable, enable slider and set values
                    stackSizeSlider.maxValue = item.Def.MaxStackSize;
                    sliderLabelRight.text = item.Def.MaxStackSize.ToString();
                    stackSizeSlider.value = item.StackSize;
                    stackSizeSlider.gameObject.SetActive(true);
                    sliderLabelTop.text = "Stack Size";
                }
            }
            else
            {
                // Slot is empty, set defaults
                defDropdown.value = 0;
                nameText.text = "Selected slot is empty.";
                sliderLabelTop.text = "";
            }
        }
        else
        {
            // No slot is selected, set defaults
            defDropdown.value = 0;
            defDropdown.interactable = false;
            nameText.text = "No slot selected.";
            sliderLabelTop.text = "";
        }
    }

    public void OnDefDropdownChanged(int index)
    {
        // First check if any slot is selected
        if (selectedSlotVar.Value >= 0)
        {
            if (index == 0)
            {
                // Index 0 -> Dropdown set to "Empty", so remove the current item from the slot
                inventory.RemoveItemInSlot(selectedSlotVar.Value);
                selectionChangedEvent.Raise();
            }
            else
            {
                // Fetch the item def, then create a new item with that def and put it into the slot
                var defId = defDropdown.options[index].text;
                var itemDef = itemDefList.LookupById[defId];
                inventory.PutNewItemIntoSlot(selectedSlotVar.Value, itemDef);
                selectionChangedEvent.Raise();
            }
        }
    }

    public void OnStackSizeSliderChanged(float value)
    {
        // First check if slider is active, slot is selected and has an item
        if (stackSizeSlider.gameObject.activeSelf && selectedSlotVar.Value >= 0)
        {
            var item = inventory.GetItemInSlot(selectedSlotVar.Value);
            if (item != null)
            {
                // Set new stack size for item, and trigger update event
                item.StackSize = (int) value;
                selectionChangedEvent.Raise();
            }
        }
    }
}
