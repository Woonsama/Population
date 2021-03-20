﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPopup : MonoBehaviour
{
    [SerializeField]
    private GameObject Sound = null;
    [SerializeField]
    private GameObject HowTo = null;
    [SerializeField]
    private GameObject Credit = null;

    [SerializeField]
    private GameObject Back = null;

    [SerializeField]
    private GameObject Buttons = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickBack()
    {
        Sound.SetActive(false);
        HowTo.SetActive(false);
        Credit.SetActive(false);

        Buttons.SetActive(true);
        Back.SetActive(false);
    }

    public void clickSound()
    {
        Buttons.SetActive(false);
        Sound.SetActive(true);
        Back.SetActive(true);
    }

    public void clickHowTo()
    {
        Buttons.SetActive(false);
        HowTo.SetActive(true);
        Back.SetActive(true);
    }

    public void clickCredit()
    {
        Buttons.SetActive(false);
        Credit.SetActive(true);
        Back.SetActive(true);
    }
}
