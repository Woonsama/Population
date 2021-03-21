using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPopup : MonoBehaviour
{
    public Text title;

    public GameObject Sound;
    public GameObject HowTo;
    public GameObject Credit;

    public GameObject Back;

    public GameObject Buttons;

    public Slider bgm;
    public Slider sfx;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bgm.value = PlayerPrefs.GetFloat("BGM", 1f);
        sfx.value = PlayerPrefs.GetFloat("SFX", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = bgm.value;
        //audioSource.volume = sfx.value;
    }

    public void clickBack()
    {
        title.text = "옵션";

        PlayerPrefs.SetFloat("BGM", bgm.value);
        PlayerPrefs.SetFloat("SFX", sfx.value);

        Sound.SetActive(false);
        HowTo.SetActive(false);
        Credit.SetActive(false);

        Buttons.SetActive(true);
        Back.SetActive(false);
    }

    public void clickSound()
    {
        title.text = "사운드";
        
        Buttons.SetActive(false);
        Sound.SetActive(true);
        Back.SetActive(true);
    }

    public void clickHowTo()
    {
        title.text = "게임 방법";

        Buttons.SetActive(false);
        HowTo.SetActive(true);
        Back.SetActive(true);
    }

    public void clickCredit()
    {
        title.text = "크레딧";

        Buttons.SetActive(false);
        Credit.SetActive(true);
        Back.SetActive(true);
    }

    public void clickExit()
    {
        Application.Quit();
    }
}
