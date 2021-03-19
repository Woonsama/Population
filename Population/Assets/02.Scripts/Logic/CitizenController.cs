using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CitizenController : MonoBehaviour
{
    public List<Citizen> list_Citizen = new List<Citizen>();

    /// <summary>
    /// 웨이브 클리어 후 시민 인원 정리
    /// </summary>
    public void UpdateCitizen()
    {
        foreach(Citizen citizen in list_Citizen)
        {
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