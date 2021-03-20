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
    //현재 인원 수
    public int currentHumanCnt { get; set; } = 0;
    //최소 인원 수
    public int minHumanCnt { get; set; } = 0;
    //토탈 인원
    public int totalHumanCnt { get; set; } = 0;
    //인원 정보
    public CitizenCnt citizenCnt = new CitizenCnt();

    //축제 차입
    public EEventType eEventType;

    public GameData()
    {
        eEventType = EEventType.None;
    }

    public void Do_LoadData()
    {

    }

    public void Do_SaveData()
    {

    }

    public void SetEventType()
    {
        eEventType = (EEventType)Random.Range((int)EEventType.Start, (int)EEventType.End);
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

    public int GetCurrentCount()
    {
        return youngCnt + manCnt + womenCnt + oldCnt;
    }
}

public enum EEventType
{
    HyungZak = 0,
    PoongZak = 1,
    Festival = 2,
    Chosik = 3,
    HoiChun = 4,
    Goryujang = 5,
    None = 6,
    
    Start = HyungZak,
    End = Goryujang + 1,
}