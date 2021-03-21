using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Image fadeImg;

    public Image[] tutorialImg;

    private int count = 0;

    private bool doing = false;
    // Start is called before the first frame update
    void Start()
    {
        doing = true;
        StartCoroutine(fadeOut(fadeImg));
    }

    // Update is called once per frame
    void Update()
    {
        if(!doing && Input.GetKeyDown(KeyCode.Space))
        {
            if(count >= 4)
            {
                doing = true;
                StartCoroutine(fadeIn());
            }
            else
            { 
                doing = true;
                StartCoroutine(fadeOut(tutorialImg[count++]));
            }
        }
    }

    IEnumerator fadeOut(Image img)
    {
        doing = true;
        Color fadeColor = img.color;

        while (fadeColor.a > 0f)
        {
            fadeColor.a -= 0.08f;
            img.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 0f;
        img.color = fadeColor;
        doing = false;
    }

    IEnumerator fadeIn()
    {
        doing = true;
        Color fadeColor = fadeImg.color;

        while (fadeColor.a <= 1f)
        {
            fadeColor.a += 0.08f;
            fadeImg.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 1f;
        fadeImg.color = fadeColor;
        doing = false;
        SceneManager.LoadScene("Kws_Test");
    }
    
}
