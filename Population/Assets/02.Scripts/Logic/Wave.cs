using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    [Header("현재 웨이브")]
    public int curWave = 1;

    [Header("웨이브 전체 클리어 여부")]
    public bool isWaveAllClear = false;

    public void WaveClear()
    {
        if(curWave < Const.c_MaxWaveCnt)
        {
            curWave++;
        }
        else if(curWave == Const.c_MaxWaveCnt)
        {
            isWaveAllClear = true;
        }
    }
}