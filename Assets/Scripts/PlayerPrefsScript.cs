using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{

    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        // ui = Find;
        ui = FindObjectOfType<UIManager>();

        if(ui != null) {
            // ui.PlayerPrefs.text = "Changed in Player Prefs Script";

            // SaveData();
            ui.PlayerPrefs.text = PlayerPrefs.GetString("name", "Name Not Found");

        }
        else {
            Debug.Log("UI Manager Not Found");
        }

    }

    public void SaveData() {
        // Player prefs is probably a dictionary
        // <Key, Value> Pair
        //
        Debug.Log("Saving Data");
        PlayerPrefs.SetString("name", "Will");
    }

    // Save data
    // PlayerPrefs.SetInt("HighScore", 100);
    // PlayerPrefs.SetString("PlayerName", "John");

    // // Load data
    // int highScore = PlayerPrefs.GetInt("HighScore", 0);
    // string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");


}
