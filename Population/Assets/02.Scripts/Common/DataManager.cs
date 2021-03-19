using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBase<DataManager>
{
    public TestData testData = new TestData();

    public DataManager()
    {
        LoadData();
    }

    public void LoadData()
    {
        testData.Do_LoadData();
    }

    public void SaveData()
    {
        testData.Do_SaveData();
    }
}