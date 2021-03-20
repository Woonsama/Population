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

    [Header("데이터매니저")]
    public DataManager dataManager;

    [Header("결과팝업창")]
    public GameObject resultPopup;

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
            citizenController.Init(ref dataManager.gameData);
        }
        else
        {
            citizenController.UpdateCitizen(ref dataManager.gameData);
        }

        ("현재 웨이브 = " + dataManager.waveData.wave.curWave).Log();

        clearManager.isWaveClear = false;

        //클리어 까지 대기
        while(!clearManager.isWaveClear)
        {
            if(dataManager.gameData.currentHumanCnt < dataManager.gameData.minHumanCnt)
            {
                //게임 패배
                resultPopup.SetActive(true);
                resultPopup.GetComponent<Result>().badeEnding();
            }
            yield return null;
        }

        //웨이브 클리어
        dataManager.waveData.WaveClear();

        "플레이어 숨김 - Clear".Log();
        playerController.HidePlayer();

        if (dataManager.waveData.GetIsWaveAllClear())
        {
            //게임 최종 클리어
            resultPopup.SetActive(true);
            resultPopup.GetComponent<Result>().ending();

        }
        else
        {
            //각 스테이지 클리어
            resultPopup.SetActive(true);
            resultPopup.GetComponent<Result>().roundClear();

            citizenController.SetNextYear(dataManager.gameData);
        }
    }
}