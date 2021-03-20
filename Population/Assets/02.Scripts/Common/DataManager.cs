using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DataManager : MonoBehaviour
{
    public WaveData waveData = new WaveData();
    public GameData gameData = new GameData();

    public DataManager()
    {
        LoadData();
    }

    public void LoadData()
    {
        waveData.Do_LoadData();
        gameData.Do_LoadData();
    }

    public void SaveData()
    {
        waveData.Do_SaveData();
        gameData.Do_SaveData();
    }
}