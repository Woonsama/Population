using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("플레이어")]
    public GameObject player;

    private CitizenController citizenController;
    private DataManager dataManager;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        dataManager.LoadData();
    }
}