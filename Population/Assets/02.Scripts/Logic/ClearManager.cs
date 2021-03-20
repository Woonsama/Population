using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    public bool isWaveClear { get; set; }

    private void Update()
    {
        //TEST
        if (Input.GetKeyDown(KeyCode.F1)) isWaveClear = true;

        if(!isWaveClear)
        {

        }
    }
}