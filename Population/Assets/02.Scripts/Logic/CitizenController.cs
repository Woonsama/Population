using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CitizenController : MonoBehaviour
{
    [Header("시민")]
    public GameObject young;
    public GameObject man;
    public GameObject women;
    public GameObject old;

    [Header("확률 정보")]
    public CitizenChangePercent citizenChangePercent;

    [Header("시민 부모")]
    public Transform parent;

    [Header("시민 생성 포지션")]
    public Vector2[] citizenCreatePos;

    [Header("시민 리스트")]
    public List<GameObject> list_Citizen = new List<GameObject>();

    public void Init()
    {
        list_Citizen.Clear();

        //Create Young Citizen
        for(int i = 0; i < Const.c_Initial_Young_Cnt; i++)
        {
            CreateCitizen(young, "Young");
        }

        //Create Man Citizen
        for (int i = 0; i < Const.c_Initial_Man_Cnt; i++)
        {
            CreateCitizen(man, "Man");
        }

        //Create Women Citizen
        for (int i = 0; i < Const.c_Initial_WomenCnt; i++)
        {
            CreateCitizen(women, "Women");
        }

        //Create Old Citizen
        for (int i = 0; i < Const.c_Initial_Old_Cnt; i++)
        {
            CreateCitizen(old, "Old");
        }
    }

    public void ClearCitizen(GameData gameData)
    {
        foreach (GameObject citizenObj in list_Citizen)
        {
            Citizen citizen = citizenObj.GetComponent<Citizen>();
            gameData.citizenCnt.Reset();

            switch (citizen.eCitizenType)
            {
                case Citizen.ECitizenType.Young:
                    gameData.citizenCnt.youngCnt++;
                    break;
                case Citizen.ECitizenType.Man:
                    gameData.citizenCnt.manCnt++;
                    break;
                case Citizen.ECitizenType.Women:
                    gameData.citizenCnt.womenCnt++;
                    break;
                case Citizen.ECitizenType.Old:
                    gameData.citizenCnt.oldCnt++;
                    break;
                default:
                    break;
            }

            list_Citizen.Clear();
        }
    }

    public void UpdateCitizen(GameData gameData)
    {
        int priorYoungCount = gameData.citizenCnt.youngCnt;
        int priorManCount = gameData.citizenCnt.manCnt;
        int priorWomenCount = gameData.citizenCnt.womenCnt;
        int prioroldCount = gameData.citizenCnt.oldCnt;

        //다음 스테이지 인원 정리

        for(int i = 0; i < prioroldCount; i++)
        {
            //노인 사망 처리
            if (Random.Range(1, 100 + 1) <= citizenChangePercent.oldToDie)
            {
                gameData.citizenCnt.oldCnt--;
            }
        }

        for (int i = 0; i < priorWomenCount; i++)
        {
            //여성이 아이를 낳는 경우
            if (Random.Range(1, 100 + 1) <= citizenChangePercent.womenGenerate)
            {
                gameData.citizenCnt.youngCnt++;
            }
        }

        for (int i = 0; i < priorWomenCount; i++)
        {
            //여성 -> 노인
            if (Random.Range(1, 100 + 1) <= citizenChangePercent.womenToOld)
            {
                gameData.citizenCnt.womenCnt--;
                gameData.citizenCnt.oldCnt++;
            }
        }

        for (int i = 0; i < priorManCount; i++)
        {
            //남성 -> 여성 or 남성
            if (Random.Range(1, 100 + 1) <= citizenChangePercent.man_take)
            {
                if (Random.Range(1, 100 + 1) < 50)
                    gameData.citizenCnt.womenCnt++;
                else
                    gameData.citizenCnt.manCnt++;
            }
        }

        for (int i = 0; i < priorManCount; i++)
        {
            //남성 -> 노인
            if (Random.Range(1, 100 + 1) <= citizenChangePercent.manToOld)
            {
                gameData.citizenCnt.manCnt--;
                gameData.citizenCnt.oldCnt++;
            }
        }

        for (int i = 0; i < priorYoungCount; i++)
        {
            //아이 -> 어른
            if (Random.Range(1, 100 + 1) <= citizenChangePercent.youngToAdult)
            {
                gameData.citizenCnt.youngCnt--;

                if (Random.Range(1, 100 + 1) < 50)
                    gameData.citizenCnt.womenCnt++;
                else
                    gameData.citizenCnt.manCnt++;
            }
        }


        //정리한 인원 생성
        for (int i = 0; i < gameData.citizenCnt.youngCnt; i++)
        {
            CreateCitizen(young, "Young");
        }

        for (int i = 0; i < gameData.citizenCnt.manCnt; i++)
        {
            CreateCitizen(man, "Man");
        }

        for (int i = 0; i < gameData.citizenCnt.womenCnt; i++)
        {
            CreateCitizen(women, "Women");
        }

        for (int i = 0; i < gameData.citizenCnt.oldCnt; i++)
        {
            CreateCitizen(old, "Old");
        }
    }

    private void CreateCitizen(GameObject citizenObj, string name)
    {
        var obj = Instantiate(citizenObj, parent);
        var citizen = obj.GetComponent<Citizen>();

        switch (name)
        {
            case "Young":
                citizen.eCitizenType = Citizen.ECitizenType.Young;
                break;
            case "Man":
                citizen.eCitizenType = Citizen.ECitizenType.Man;
                break;
            case "Women":
                citizen.eCitizenType = Citizen.ECitizenType.Women;
                break;
            case "Old":
                citizen.eCitizenType = Citizen.ECitizenType.Old;
                break;
            default:
                break;
        }

        SetCitizenPosition(obj);
        obj.name = name;
        list_Citizen.Add(obj);
    }

    private void SetCitizenPosition(GameObject obj)
    {
        obj.transform.position = citizenCreatePos[Random.Range(0, citizenCreatePos.Length)];
    }
}

[System.Serializable]

public class CitizenChangePercent
{
    [Header("아이가 어른이 될 확률")]
    public int youngToAdult;

    [Header("아이가 어른이 되서 남자가 될 확률")]
    public int young_man;

    [Header("남자가 남성 혹은 여성을 되려올 확률")]
    public int man_take;

    [Header("남자가 노인이 될 확률")]
    public int manToOld;

    [Header("여성이 아이를 낳을 확률")]
    public int womenGenerate;

    [Header("여성이 노인이 될 확률")]
    public int womenToOld;

    [Header("노인이 사망할 확률")]
    public int oldToDie;

    [Header("최저 인구수 비율")]
    public int populationPercent;
}