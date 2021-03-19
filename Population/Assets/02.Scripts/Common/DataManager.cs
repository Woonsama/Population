using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public WaveData waveData = new WaveData();
    public ScoreData scoreData = new ScoreData();

    public DataManager()
    {
        LoadData();
    }

    public void LoadData()
    {
        waveData.Do_LoadData();
        scoreData.Do_LoadData();
    }

    public void SaveData()
    {
        waveData.Do_SaveData();
        scoreData.Do_SaveData();
    }
}