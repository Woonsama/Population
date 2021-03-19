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

public class ScoreData
{
    public int score { get; private set; }

    public ScoreData()
    {
        score = 0;
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void Do_LoadData()
    {

    }

    public void Do_SaveData()
    {

    }
}