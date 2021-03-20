using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : ObjectBase
{
    [Header("확인용 - 플레이어 접근")]
    public Player player;
    public GameObject playerObj;

    [Header("접근 범위")]
    public float distance;

    [Header("확인용 - 현재 거리")]
    public float currentDistance;

    [Header("확인용 - 플레이어와 가까이 있는지")]
    public bool isNear= false;

    [Header("확인용 - 시민 보유 여부")]
    public bool isCitizen = false;

    [Header("데이터매니저")]
    public DataManager dataManager;

    [Header("클리어매니저")]
    public ClearManager clearManager;

    [Header("사운드매니저")]
    public SoundManager soundManager;

    private AudioSource truckSource;

    [Header("차감 될 데이터 [포인트]")]
    public int youngCnt;
    public int manCnt;
    public int womenCnt;
    public int oldCnt;


    public void SetPlayer(Player player)
    {
        this.player = player;
        playerObj = player.gameObject;
    }

    private void Awake()
    {
        truckSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerObj != null)
        {
            currentDistance = Vector2.Distance(playerObj.transform.position, transform.position);

            if (currentDistance < distance)
            {
                isNear = true;
            }
            else
            {
                isNear = false;
            }

            if (playerObj.transform.childCount == 3)
            {
                isCitizen = true;
            }
            else
            {
                isCitizen = false;
            }
        }
    }

    public void Lift()
    {
        if (isCitizen)
        {
            GameObject citizenObj = playerObj.transform.GetChild(2).gameObject;
            Citizen citizen = citizenObj.GetComponent<Citizen>();      
            citizen.transform.SetParent(null);

            citizen.transform.position = playerObj.transform.GetChild(1).transform.position;
            citizen.transform.eulerAngles = Vector3.zero;

            if (isNear)
            {
                switch (citizen.eCitizenType)
                {
                    case Citizen.ECitizenType.Young:
                        dataManager.gameData.citizenCnt.youngCnt--;
                        dataManager.gameData.needPoint -= youngCnt;
                        soundManager.PlayOnShot_YoungTruck(truckSource);
                        break;
                    case Citizen.ECitizenType.Man:
                        dataManager.gameData.citizenCnt.manCnt--;
                        dataManager.gameData.needPoint -= manCnt;
                        soundManager.PlayOnShot_ManTruck(truckSource);
                        break;
                    case Citizen.ECitizenType.Women:
                        dataManager.gameData.citizenCnt.womenCnt--;
                        dataManager.gameData.needPoint -= womenCnt;
                        soundManager.PlayOnShot_WomenTruck(truckSource);
                        break;
                    case Citizen.ECitizenType.Old:
                        dataManager.gameData.citizenCnt.oldCnt--;
                        dataManager.gameData.needPoint -= oldCnt;
                        soundManager.PlayOnShot_OldTruck(truckSource);
                        break;
                    default:
                        break;
                }

                dataManager.gameData.currentHumanCnt= dataManager.gameData.citizenCnt.GetCurrentCount();

                GameObject.Destroy(citizenObj);
                isNear = false;
            }
        }
        PointCheck();
    }

    private void PointCheck()
    {
        if(dataManager.gameData.needPoint <= 0)
        {
            clearManager.isWaveClear = true;
        }
    }
}