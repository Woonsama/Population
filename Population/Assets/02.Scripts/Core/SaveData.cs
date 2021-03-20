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

public class PointData
{
    public int point { get; private set; }
    public int currentHumanCnt { get; private set; }

    public PointData()
    {
        point = 0;
    }


    public void SetPoint()
    {

    }

    public void Do_LoadData()
    {

    }

    public void Do_SaveData()
    {
        
    }
}