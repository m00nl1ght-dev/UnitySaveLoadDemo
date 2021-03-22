using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveManager/JsonSaveManager")]
public class JsonSaveManager : SaveManager
{
    // Inspector editable fields
    public string filePath;
    
    public override void SaveToSlot(int saveSlot)
    {
        var saveData = FetchSaveData();
        var path = Application.persistentDataPath + "/" + filePath.Replace("%i", saveSlot.ToString());
        var dir = new FileInfo(path).Directory;
        if (dir != null) Directory.CreateDirectory(dir.FullName);
        File.WriteAllText(path, JsonUtility.ToJson(saveData));
    }

    public override void LoadFromSlot(int saveSlot)
    {
        var path = Application.persistentDataPath + "/" + filePath.Replace("%i", saveSlot.ToString());
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var saveData = JsonUtility.FromJson<SaveData>(json);
            ApplyLoadedData(saveData);
        }
    }
}
