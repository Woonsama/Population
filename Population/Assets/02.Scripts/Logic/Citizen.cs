using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : ObjectBase
{
    public enum ECitizenType
    {
        Young = 0,
        Man, Women,
        Old,

        Count = Old,
    };

    [Header("시민 종류")]
    public ECitizenType eCitizenType;

    protected override IEnumerator OnAwakeCoroutine()
    {
        Init();
        return base.OnAwakeCoroutine();
    }

    private void Init()
    {
        SetCitizenType();
    }

    private void SetCitizenType()
    {
        eCitizenType = (ECitizenType)Random.Range(0, (int)ECitizenType.Count);
    }

}