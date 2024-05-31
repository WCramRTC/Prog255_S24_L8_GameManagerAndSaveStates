using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Hp;
    public Vector3 currentLocation;

    public string DisplayInfo() {
        return $"{Name} - {Hp} - {currentLocation} - {currentLocation.ToShortString()}";
    }
}
