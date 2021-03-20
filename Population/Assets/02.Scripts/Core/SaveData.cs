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
    //필요 포인트
    public int needPoint { get; set; } = 0;
    //현재 포인트
    public int currentHumanCnt { get; set; } = 0;
    //최소 포인트
    public int minHumanCnt { get; set; } = 0;
    //인원 정보
    public CitizenCnt citizenCnt = new CitizenCnt();

    public GameData()
    {
        
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

    public int GetTotalCount()
    {
        return youngCnt + manCnt + womenCnt + oldCnt;
    }
}