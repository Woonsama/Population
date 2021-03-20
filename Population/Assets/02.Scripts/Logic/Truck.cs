using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : ObjectBase
{
    [Header("확인용 - 플레이어 접근")]
    public Player player;

    [Header("접근 범위")]
    public float distance;

    [Header("확인용 - 플레이어와 가까이 있는지")]
    [SerializeField] private bool isNear= false;

    private void Update()
    {
        CheckPlayer();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void CheckPlayer()
    {
        if(player != null)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < distance)
            {
                isNear = true;
            }
            else
            {
                isNear = false;
            }
        }
    }

    public void ActiveOn()
    {
        gameObject.SetActive(true);
    }

    public void ActiveOff()
    {
        gameObject.SetActive(false);
    }
}