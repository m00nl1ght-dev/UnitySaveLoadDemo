using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    // Inspector editable fields
    public ItemDefList itemDefList;
    public ItemSlotVar selectedItemSlotVar;
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
        defOptions.AddRange(itemDefList.itemDefs.Select(d => new Dropdown.OptionData(d.defId)).ToList());
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
        if (selectedItemSlotVar.Slot != null)
        {
            var item = selectedItemSlotVar.Slot.CurrentItem;
            if (item != null && item.Def != null)
            {
                // Slot is not empty, set item texts
                nameText.text = item.Def.itemName;
                defDropdown.value = itemDefList.itemDefs.IndexOf(item.Def) + 1;
                descriptionText.text = item.Def.description;
                if (item.Def.maxStackSize > 1)
                {
                    // Item is stackable, enable slider and set values
                    stackSizeSlider.maxValue = item.Def.maxStackSize;
                    sliderLabelRight.text = item.Def.maxStackSize.ToString();
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
        if (selectedItemSlotVar.Slot != null)
        {
            if (index == 0)
            {
                // Index 0 -> Dropdown set to "Empty", so remove the current item from the slot
                selectedItemSlotVar.Slot.RemoveItem();
                selectionChangedEvent.Raise();
            }
            else
            {
                // Fetch the item def, then create a new item with that def and put it into the slot
                var defId = defDropdown.options[index].text;
                var itemDef = itemDefList.LookupById[defId];
                selectedItemSlotVar.Slot.PutNewItem();
                selectedItemSlotVar.Slot.CurrentItem.Def = itemDef;
                selectionChangedEvent.Raise();
            }
        }
    }

    public void OnStackSizeSliderChanged(float value)
    {
        if (!stackSizeSlider.gameObject.activeSelf) return;
        // First check if any slot is selected and has an item
        if (selectedItemSlotVar.Slot != null && selectedItemSlotVar.Slot.CurrentItem != null)
        {
            // Set new stack size for item
            selectedItemSlotVar.Slot.CurrentItem.StackSize = (int) value;
        }
    }
}
