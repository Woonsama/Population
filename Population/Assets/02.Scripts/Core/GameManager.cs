using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("시민 컨트롤러")]
    public CitizenController citizenController;

    [Header("플레이어 컨트롤러")]
    public PlayerController playerController;

    private DataManager dataManager = new DataManager();

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        playerController.CreatePlayer();
        citizenController.Init();
    }
}