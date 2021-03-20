using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData
{
    public TestData()
    {

    }

    public void Do_SaveData()
    {

    }

    public void Do_LoadData()
    {

    }
}

public class WaveData
{
    public Wave wave = new Wave();

    public WaveData()
    {
        wave.curWave = 1;
        wave.isWaveAllClear = false;
    }

    public void WaveClear()
    {
        wave.WaveClear();
    }

    public bool GetIsWaveAllClear()
    {
        return wave.isWaveAllClear;
    }

    public void Do_LoadData()
    {

    }

    public void Do_SaveData()
    {

    }
}

public class GameData
{
    public int point { get; private set; }
    public int currentHumanCnt { get; private set; }
    public int minHumanCnt { get; private set;  }
    public CitizenCnt citizenCnt = new CitizenCnt();

    public GameData()
    {
        point = 0;
    }

    public void Do_LoadData()
    {

    }

    public void Do_SaveData()
    {

    }
}

[System.Serializable]

public class CitizenCnt
{
    public int youngCnt;
    public int manCnt;
    public int womenCnt;
    public int oldCnt;

    public CitizenCnt()
    {
        Reset();
    }

    public void Reset()
    {
        youngCnt = manCnt = womenCnt = oldCnt = 0;
    }
}