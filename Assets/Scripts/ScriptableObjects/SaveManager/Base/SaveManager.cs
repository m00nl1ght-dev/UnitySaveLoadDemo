using UnityEngine;

public abstract class SaveManager : ScriptableObject
{
    // Inspector editable fields, all game elements with persistent data
    public Inventory mainInventory;
    
    // Other inspector editable fields
    public GameEvent refreshInventoryEvent;

    // Abstract save/load methods to be implemented by each SaveManager type
    public abstract void SaveToSlot(int saveSlot);
    public abstract void LoadFromSlot(int saveSlot);

    // Collects the data from all persistent game elements, and puts it into a new SaveData instance
    protected SaveData FetchSaveData()
    {
        return new SaveData()
        {
            inventoryData = mainInventory.Save()
            // Fetch data from all other saved game elements here too
            // ...
        };
    }

    // Applies the data from a SaveData instance back to all persistent game elements
    protected void ApplyLoadedData(SaveData saveData)
    {
        mainInventory.Load(saveData.inventoryData);
        refreshInventoryEvent.Raise();
        // Apply to all other saved game elements here too
        // ...
    }
}
