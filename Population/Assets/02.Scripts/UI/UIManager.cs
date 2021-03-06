using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Kind
    {
        CHILD = 0,
        MAN,
        WOMAN,
        OLD,
        KIN_MAX,
    };

    public Text tYear = null;
    public Text tPoint = null;
    public Text tPopulation = null;

    public Text[] tCount = null; // 아이, 남성, 여성, 노인

    private bool option = false;

    public GameObject optionPopup = null;

    [Header("데이터 매니저")]
    public DataManager dataManager;


    // Start is called before the first frame update
    void Start()
    {
        SetText();

    }

    // Update is called once per frame
    void Update()
    {
        SetText();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            option = !option;
            optionPopup.SetActive(option);

            if (option)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    private void SetText()
    {
        // seting
        setCount(Kind.CHILD, dataManager.gameData.citizenCnt.youngCnt);
        setCount(Kind.MAN, dataManager.gameData.citizenCnt.manCnt);
        setCount(Kind.WOMAN, dataManager.gameData.citizenCnt.womenCnt);
        setCount(Kind.OLD, dataManager.gameData.citizenCnt.oldCnt);

        setYear(dataManager.waveData.wave.curWave);

        setPoint(dataManager.gameData.needPoint);

        setPopulation(dataManager.gameData.currentHumanCnt, dataManager.gameData.minHumanCnt);
    }

    public void setYear(int year)
    {
        tYear.text = year.ToString() + " 년차";
    }

    public void setPoint(int point)
    {
        tPoint.text = point.ToString() + " pt";
    }

    public void setPopulation(int nowPopulation, int minPopulation)
    {
        tPopulation.text = nowPopulation.ToString() + " 명 / " + minPopulation.ToString() + " 명";
    }

    public void setCount(Kind kind, int count)
    {
        tCount[(int)kind].text = count.ToString();
    }
}
