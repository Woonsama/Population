using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        //roundClear();
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
        {
            if (title.text == "주민이 모두 떠났습니다")
            {
                SceneManager.LoadScene("Ending");
            }
            resultObj.SetActive(false);

        }
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

        // 결과창 끝. 이동
        if (count >= scripts.Length)
        {
            Time.timeScale = 1f;
            this.gameObject.SetActive(false);

            if(title.text == "당신은 마을을 지켰습니다")
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
    
    public void roundClear()
    {
        Time.timeScale = 0f;
        count = 0;
        doing = true;
        StartCoroutine("fadeOutIn");

        string str_Event = string.Empty;
        string str_EventContents = string.Empty;


        switch (dataManager.gameData.eEventType)
        {
            case EEventType.HyungZak:
                str_Event = "흉작";
                str_EventContents = "이번 라운드에 버려야하는 포인트 +3\n";
                break;
            case EEventType.PoongZak:
                str_Event = "풍작";
                str_EventContents = "이번 라운드에 버려야하는 포인트 -3\n";
                break;
            case EEventType.Festival:
                str_Event = "축제";
                str_EventContents = "이번 라운드에 추가된 아이들의 수 * 1.5\n";
                break;
            case EEventType.Chosik:
                str_Event = "초식";
                str_EventContents = "이번 라운드에 추가된 아이들의 수 * 0.5\n";
                break;
            case EEventType.HoiChun:
                str_Event = "회춘";
                str_EventContents = "15%의 확률로 노인은 아이가 됩니다\n";
                break;
            case EEventType.Goryujang:
                str_Event = "악습";
                str_EventContents = "이전 라운드의 노인은 모두 죽은 채로 시작합니다\n";
                break;
            case EEventType.None:
                str_Event = "이벤트가 발생하지 않았습니다";
                break;
            default:
                break;
        }

        title.text = (dataManager.waveData.wave.curWave - 1) + " 년차 완료";

        scripts = new string[3];

        scripts[0] = "마을을 유지하기 위해\n"
                        + dataManager.gameData.citizenCnt.youngCnt + " 명의 어린아이와\n"
                        + (dataManager.gameData.citizenCnt.manCnt + dataManager.gameData.citizenCnt.manCnt) + " 명의 성인\n"
                        + dataManager.gameData.citizenCnt.oldCnt + " 명의 노인이\n은퇴하였습니다.\n\n"
                        + "은퇴를 하게 된 그들은\n마을과 당신의 안녕을 빌어주며\n"
                        + "눈물을 짓습니다";

        scripts[1] = "(" + str_Event +  ")\n"
                        + str_EventContents + "\n\n"
                        + dataManager.gameData.totalBornCnt + " 명의 어린아이가 출생했습니다.\n"
                        //+ dataManager.gameData.youngDeadCnt + " 명의 어린아이가 자연사하였습니다.\n"
                        + dataManager.gameData.youngToAdultCnt + " 명의 아이가 성인이 되었습니다.\n"
                        + dataManager.gameData.comeAdultCnt + " 명의 성인이 마을에 찾아왔습니다.\n"
                        + dataManager.gameData.totalOldCnt+ " 명의 성인이 노인이 되었습니다.\n"
                        + dataManager.gameData.deadAdult + " 명의 성인이 자연사하였습니다.\n"
                        + dataManager.gameData.deadOld + " 명의 노인이 노화로 인해 자연사하였습니다.\n";
        scripts[2] = "현재 주민 수\n\n"
                        + "아이 : " + dataManager.gameData.citizenCnt.youngCnt
                        + "남성 : " + dataManager.gameData.citizenCnt.manCnt
                        + "여성 : " + dataManager.gameData.citizenCnt.womenCnt
                        + "노인 : " + dataManager.gameData.citizenCnt.oldCnt;
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
                        + dataManager.gameData.killYoungCnt + " 명의 어린아이들과\n"
                        + dataManager.gameData.killAdultCnt + " 명의 성인들\n"
                        + dataManager.gameData.killOldCnt + " 명의 노인의\n사퇴서 위에 세워졌다는 것을\n기억하시길 바랍니다";
    }
}
