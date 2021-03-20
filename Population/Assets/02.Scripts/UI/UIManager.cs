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

    [SerializeField]
    private Text tYear = null;
    [SerializeField]
    private Text tPoint = null;
    [SerializeField]
    private Text tPopulation = null;

    [SerializeField]
    private Text[] tCount = null; // 아이, 남성, 여성, 노인

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {

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
