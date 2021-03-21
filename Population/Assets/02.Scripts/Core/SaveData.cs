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

    //총 태어난 사람 수
    public int totalBornCnt { get; set; } 

    //총 아이 사망 수
    public int youngDeadCnt { get; set; }

    //아이가 성인이 된 수
    public int youngToAdultCnt { get; set; }

    //마을에 찾아 온 성인의 수
    public int comeAdultCnt { get; set; }

    //성인이 노인이 된 수
    public int totalOldCnt { get; set; }

    //성인이 자연사 한 수
    public int deadAdult { get; set; }

    //자연사한 노인 수
    public int deadOld { get; set; }

    //은퇴당한 아이 수
    public int killYoungCnt { get; set; }

    //은퇴당한 어른 수
    public int killAdultCnt { get; set; }

    //은퇴당한 노인 수
    public int killOldCnt { get; set; }

    //초기 포인트
    public int initialPoint { get; set; }

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

    public void Arrange()
    {
        if (youngCnt < 0) youngCnt = 0;
        if (manCnt < 0) manCnt = 0;
        if (womenCnt < 0) womenCnt = 0;
        if (oldCnt < 0) oldCnt = 0;
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