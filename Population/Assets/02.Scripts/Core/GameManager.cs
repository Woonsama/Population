using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("시민 컨트롤러")]
    public CitizenController citizenController;

    [Header("플레이어 컨트롤러")]
    public PlayerController playerController;

    [Header("클리어 매니저")]
    public ClearManager clearManager;

    private DataManager dataManager = new DataManager();

    private void Awake()
    {
        StartCoroutine(Game_Coroutine());
    }

    private IEnumerator Game_Coroutine()
    {       
        for(int i = 0; i < Const.c_MaxWaveCnt; i++)
        {
            "새 웨이브".Log();
            yield return StartCoroutine(Wave_Coroutine());
        }

        yield break;
    }

    private IEnumerator Wave_Coroutine()
    {
        yield return StartCoroutine(WaveStart());
        
        yield break;
    }

    private IEnumerator WaveStart()
    {
        "플레이어 생성 - Init".Log();
        playerController.CreatePlayer();

        "시민 생성 - Init".Log();
        if(dataManager.waveData.wave.curWave == 1)
        {
            citizenController.Init(dataManager.gameData);
        }
        else
        {
            citizenController.UpdateCitizen(dataManager.gameData);
        }

        clearManager.isWaveClear = false;

        //클리어 까지 대기
        while(!clearManager.isWaveClear)
        {
            yield return null;
        }

        dataManager.waveData.WaveClear();

        if (dataManager.waveData.GetIsWaveAllClear())
        {
            //게임 클리어
        }
        else
        {
            //웨이브 클리어 처리

            "플레이어 삭제 - Clear".Log();
            playerController.HidePlayer();

            "시민 삭제 - Clear".Log();
            citizenController.ClearCitizen(dataManager.gameData);
        }
    }
}