using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    public void Save(int saveSlot)
    {
        Debug.Log("Saving to S" + saveSlot);
    }
    
    public void Load(int saveSlot)
    {
        Debug.Log("Loading from S" + saveSlot);
    }
}
