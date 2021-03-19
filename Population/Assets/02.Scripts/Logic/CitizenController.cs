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

    private void CreateCitizen(GameObject citizen, string name)
    {
        var obj = Instantiate(citizen, parent);
        SetCitizenPosition(obj);
        obj.name = name;
        list_Citizen.Add(obj);
    }

    private void SetCitizenPosition(GameObject obj)
    {
        obj.transform.position = citizenCreatePos[Random.Range(0, citizenCreatePos.Length)];
    }

    /// <summary>
    /// 웨이브 클리어 후 시민 인원 정리
    /// </summary>
    public void UpdateCitizen()
    {
        foreach(GameObject citizenObj in list_Citizen)
        {
            Citizen citizen = citizenObj.GetComponent<Citizen>();

            switch (citizen.eCitizenType)
            {
                case Citizen.ECitizenType.Young:
                    break;
                case Citizen.ECitizenType.Man:
                    break;
                case Citizen.ECitizenType.Women:
                    break;
                case Citizen.ECitizenType.Old:
                    break;
                default:
                    break;
            }
        }
    }
}