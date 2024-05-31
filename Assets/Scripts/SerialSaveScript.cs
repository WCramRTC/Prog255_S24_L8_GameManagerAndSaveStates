using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerDataBin {
    public string Name;
    public int Hp;

    public string DisplayInfo() {
        return $"{Name} - {Hp}";
    }
}

public class SerialSaveScript : MonoBehaviour
{
    UIManager ui;
    // static string FilePath = Application.persistentDataPath + "/playerData.bin";
    // Start is called before the first frame update

    
    void Start()
    {
        ui = FindObjectOfType<UIManager>();

        ui.SerialText.text = "Serial Text is working";

        // PlayerDataBin pd = new PlayerDataBin() {
        //     Name = "Raina",
        //     Hp = 60,
        // };

        // SaveData(pd);

        PlayerDataBin data = LoadData();
        ui.SerialText.text = data.DisplayInfo();
    }

    public void SaveData(PlayerDataBin data) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = FileLocations.FileLocationBin;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerDataBin LoadData() {
        // 1. Check if file exists

        if(File.Exists(FileLocations.FileLocationBin)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(FileLocations.FileLocationBin, FileMode.Open);

            PlayerDataBin data = formatter.Deserialize(stream) as PlayerDataBin;

            stream.Close();
            return data;
        }

        return null;
    }

    //     public PlayerData LoadData()
    // {
    //     string path = Application.persistentDataPath + "/playerData.bin";
    //     if (File.Exists(path))
    //     {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.Open);

    //         PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //         stream.Close();
    //         return data;
    //     }
    //     return null;
    // }

    //     public void SaveData(PlayerData data)
    // {
    //     BinaryFormatter formatter = new BinaryFormatter();
    //     string path = Application.persistentDataPath + "/playerData.bin";
    //     FileStream stream = new FileStream(path, FileMode.Create);

    //     formatter.Serialize(stream, data);
    //     stream.Close();
    // }
}
