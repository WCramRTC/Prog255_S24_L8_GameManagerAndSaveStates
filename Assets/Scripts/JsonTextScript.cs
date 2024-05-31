using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonTextScript : MonoBehaviour
{

    
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();

        // PlayerData pd = new PlayerData() {
        //     Name = "Will",
        //     Hp = 120,
        //     currentLocation = new Vector3(5,2,8)
        // };

        // SaveData(pd);
        PlayerData loadedData = LoadData();

        if(loadedData != null) {
            ui.JsonText.text = loadedData.DisplayInfo();
        }
        else {
            ui.JsonText.text = "Player Data not found";
        }
    }

    public void SaveData(PlayerData playerData) {

            string persistentDataPath = Application.persistentDataPath;
    string filePath = "/playerData.json";
    string fullPath = persistentDataPath + filePath;

        string json = JsonUtility.ToJson(playerData);


        // File.WriteAllText(filePath, string)
        File.WriteAllText(fullPath, json);

        Debug.Log(fullPath);
    }

    //     public void SaveData(PlayerData data)
    // {
    //     string json = JsonUtility.ToJson(data);
    //     File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    // }

    public PlayerData LoadData() {
    string persistentDataPath = Application.persistentDataPath;
    string filePath = "/playerData.json";
    string fullPath = persistentDataPath + filePath;
    
        // File.Exists(path)
        // It will check if the file exists in the first place
        if(File.Exists(fullPath)) {
            string json = File.ReadAllText(fullPath);
            return JsonUtility.FromJson<PlayerData>(json);
        }

        return null;
    }

    //     public PlayerData LoadData()
    // {
    //     string path = Application.persistentDataPath + "/playerData.json";
    //     if (File.Exists(path))
    //     {
    //         string json = File.ReadAllText(path);
    //         return JsonUtility.FromJson<PlayerData>(json);
    //     }
    //     return null;
    // }

}
