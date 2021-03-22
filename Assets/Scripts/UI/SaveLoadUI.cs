using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    // Inspector editable fields
    public SaveManager saveManager;
    
    public void Save(int saveSlot)
    {
        Debug.Log("Saving to S" + saveSlot);
        saveManager.SaveToSlot(saveSlot);
    }
    
    public void Load(int saveSlot)
    {
        Debug.Log("Loading from S" + saveSlot);
        saveManager.LoadFromSlot(saveSlot);
    }
}
