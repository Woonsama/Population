using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    const int c_Max_Wave = 6;

    [Header("현재 웨이브")]
    public int curWave = 1;

    [Header("웨이브 전체 클리어 여부")]
    public bool isWaveAllClear = false;

    public void WaveClear()
    {
        if(wave < c_Max_Wave)
        {
            wave++;
        }
        else if(wave == c_Max_Wave)
        {
            isWaveAllClear = true;
        }
    }
}