using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveManager/BinarySaveManager")]
public class BinarySaveManager : SaveManager
{
    // Inspector editable fields
    public string filePath;
    
    public override void SaveToSlot(int saveSlot)
    {
        var saveData = FetchSaveData();
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/" + filePath.Replace("%i", saveSlot.ToString());
        var dir = new FileInfo(path).Directory;
        if (dir != null) Directory.CreateDirectory(dir.FullName);
        var stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public override void LoadFromSlot(int saveSlot)
    {
        var path = Application.persistentDataPath + "/" + filePath.Replace("%i", saveSlot.ToString());
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var saveData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            ApplyLoadedData(saveData);
        }
    }
}
