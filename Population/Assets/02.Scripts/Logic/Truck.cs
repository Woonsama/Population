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
        }
    }

    public void Lift()
    {
        if(playerObj != null)
        {
            if (playerObj.transform.GetChild(2).gameObject != null)
            {
                GameObject citizenObj = playerObj.transform.GetChild(2).gameObject;
                Citizen citizen = citizenObj.GetComponent<Citizen>();

                citizen.transform.SetParent(null);

                GameObject.Destroy(citizenObj);
            }
            "Test".Log();
        }
        else
        {
            isNear = false;
        }
    }
}