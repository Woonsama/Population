using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("카메라 컨트롤러")]
    public CameraController cameraController;

    [Header("플레이어")]
    public GameObject player;

    [Header("플레이어 생성 지점")]
    public Vector2 playerCreatePos;

    private GameObject target = null;

    public void CreatePlayer()
    {
        if (target == null)
        {
            target = Instantiate(player);
        }
        else
        {
            target.SetActive(true);
        }

        target.transform.position = playerCreatePos;
        cameraController.SetTarget(target);
    }

    public void HidePlayer()
    {
        cameraController.DetachTarget();

        if(target != null)
        {
            target.SetActive(false);
        }
    }
}