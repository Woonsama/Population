using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("시민 컨트롤러")]
    public CitizenController citizenController;

    [Header("플레이어 컨트롤러")]
    public PlayerController playerController;

    [Header("클리어 매니저")]
    public ClearManager clearManager;

    private DataManager dataManager = new DataManager();

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        "플레이어 생성 - Init".Log();
        playerController.CreatePlayer();

        "시민 생성 - Init".Log();
        citizenController.Init();
    }
}