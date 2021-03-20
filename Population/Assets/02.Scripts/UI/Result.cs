using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text title;
    public Text contents;
    
    public Image fadeImg;

    public GameObject resultObj;

    private int count;
    private string[] scripts;

    private bool doing = false;

    [Header("DataManager")]
    public DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("fadeIn");
        // 엔딩에 따라 scrips에 저장되는 내용에 달라짐
        roundClear();
        //badeEnding();
        //ending();

        count = 0;
        contents.text = scripts[count++];
    }

    // Update is called once per frame
    void Update()
    {
        if (!doing && Input.GetKeyDown(KeyCode.Space))
        {
            if (count >= scripts.Length)
            {
                StartCoroutine("fadeOutIn");
                return;
            }
            contents.text = scripts[count++];
        }
    }

    IEnumerator fadeOutIn()
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

        if (count >= scripts.Length)
            resultObj.SetActive(false);
        else
            resultObj.SetActive(true);

        while (fadeColor.a > 0f)
        {
            fadeColor.a -= 0.08f;
            fadeImg.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 0f;
        fadeImg.color = fadeColor;
        doing = false;

        if (count >= scripts.Length)
        {
            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }
    }
    
    public void roundClear()
    {
        Time.timeScale = 0f;
        count = 0;
        doing = true;
        StartCoroutine("fadeOutIn");


        title.text = "N 년차 완료";

        scripts = new string[3];

        scripts[0] = "마을을 유지하기 위해\n"
                        + "N 명의 어린아이와\n"
                        + "N 명의 성인\n"
                        + "N 명의 노인이\n은퇴하였습니다.\n\n"
                        + "은퇴를 하게 된 그들은\n마을과 당신의 안녕을 빌어주며\n"
                        + "눈물을 짓습니다";

        scripts[1] = "(이벤트 이름)\n"
                        + "이벤트 설명\n\n"
                        + "N 명의 어린아이가 출생했습니다.\n"
                        + "N 명의 어린아이가 자연사하였습니다.\n"
                        + "N 명의 아이가 성인이 되었습니다.\n"
                        + "N 명의 성인이 마을에 찾아왔습니다.\n"
                        + "N 명의 성인이 노인이 되었습니다.\n"
                        + "N 명의 성인이 자연사하였습니다.\n"
                        + "N 명의 노인이 노화로 인해 자연사하였습니다.\n";
        scripts[2] = "현재 주민 수\n\n"
                        + "아이 : N\n\n"
                        + "남성 : N\n\n"
                        + "여성 : N\n\n"
                        + "노인 : N\n\n";
    }

    public void badeEnding()
    {
        Time.timeScale = 0f;
        count = 0;
        StartCoroutine("fadeOutIn");

        title.text = "주민이 모두 떠났습니다";

        scripts = new string[4];
        
        //아이
        scripts[0] = "구조조정 명단에 적힌\n수 많은 아이들의 이름을 본\n"
                        + "성인들은 분노를 참지 못 하고\n폭동을 일으켰습니다.\n\n"
                        + "마을을 유지하기 위한\n당신의 구조조정 판단은\n존중 받아 마땅하지만,\n"
                        + "어린 아이들에게 주어진 가혹한 현실은\n사람들이 납득하지 못 할 것입니다.";
        //남성
        scripts[1] = "은퇴한 남성들을 그리워하는\n여성들이 단체 이주를 결심하였습니다.\n\n"
                       + "마을을 유지하기 위한\n당신의 구조조정 판단은\n존중 받아 마땅하지만,\n"
                       + "그것은 많은 사람들의 그리움을\n증폭시키게 된 계기가 되었습니다.";
        //여성
        scripts[2] = "은퇴한 여성들을 그리워하는\n남성들이 단체 이주를 결심하였습니다.\n\n"
                       + "마을을 유지하기 위한\n당신의 구조조정 판단은\n존중 받아 마땅하지만,\n"
                       + "그것은 많은 사람들의 그리움을\n증폭시키게 된 계기가 되었습니다.";
        //노인
        scripts[3] = "은퇴한 수 많은 노인들의\n작별의 박수를 쳐 주던 젊은 주민들은\n"
                        + "본인의 미래를 예상하고는\n대규모 이주를 선택하였습니다\n\n"
                        + "마을을 유지하기 위한\n당신의 구조조정 판단은\n존중 받아 마땅하지만,\n"
                        + "그것으로 인해 생겨난 뒷모습은\n아름답지만은 않았습니다";
    }

    public void ending()
    {
        Time.timeScale = 0f;
        count = 0;
        StartCoroutine("fadeOutIn");

        title.text = "당신은 마을을 지켰습니다";

        scripts = new string[1];

        scripts[0] = "당신이 지켜낸 마을은 많은 사람들의\n낙원이 되어 줄 것이며\n"
                        + "앞으로도 당신이 관리하는 마을은\n평화를 유지할 것입니다.\n\n"
                        + "하지만 당신이 지켜낸 낙원은\n당신에 의해 '은퇴당한'\n"
                        + "N 명의 어린아이들과\n"
                        + "N 명의 성인들\n"
                        + "N 명의 노인의\n사퇴서 위에 세워졌다는 것을\n기억하시길 바랍니다";
    }
}
