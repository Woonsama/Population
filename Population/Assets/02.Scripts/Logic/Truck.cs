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

    public void SetPlayer(Player player)
    {
        this.player = player;
        playerObj = player.gameObject;
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


                GameObject.Destroy(citizenObj);
                isNear = false;
            }
        }
    }

    private void SetPoint()
    {

    }
}