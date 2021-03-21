using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popup = null;

    private float applyHeight = 0f;

    public RectTransform popupImage;
    public Text tInfo;

    public enum EPanelType
    {
        Young, Man, Women, Old,
    }

    [Header("패널 타입")]
    public EPanelType ePanelType; 

    [Header("설명")]
    public Text explain;

    [Header("CitizenType")]
    public CitizenController citizenController;

    private bool doing = false;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (doing)
            return;

        StartCoroutine("popupOpen");
        popup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if (doing)
        //    return;
        //StopCoroutine("popupOpen");
        StartCoroutine("popupClose");
        
    }

    IEnumerator popupOpen()
    {
        doing = true;
        Vector2 popupRect = popupImage.sizeDelta;
        Color color = tInfo.color;

        if(explain != null)
        SetExplainText();

        while (popupRect.y < 100f && color.a <= 1f)
        {
            popupRect.x += 20f;
            popupRect.y += 15f;
            color.a += 0.08f;
            popupImage.sizeDelta = popupRect;
            tInfo.color = color;
            yield return null;
        }

        popupRect.x = 650f;
        popupRect.y = 100f;
        color.a = 1f;
        popupImage.sizeDelta = popupRect;
        tInfo.color = color;
        doing = false;
    }

    IEnumerator popupClose()
    {
        doing = true;
        Vector2 popupRect = popupImage.sizeDelta;
        Color color = tInfo.color;

        while (popupRect.y > 0f && color.a > 0f)
        {
            popupRect.x -= 20f;
            popupRect.y -= 15f;
            color.a -= 0.08f;
            popupImage.sizeDelta = popupRect;
            tInfo.color = color;
            yield return null;
        }

        popup.SetActive(false);

        popupRect.x = 0f;
        popupRect.y = 0f;
        color.a = 1f;
        popupImage.sizeDelta = popupRect;
        tInfo.color = color;
        doing = false;
    }

    private void SetExplainText()
    {
        switch (ePanelType)
        {
            case EPanelType.Young:
                explain.text = "- 아이를 버리게 된다면 5포인트가 차감됩니다.\n" +
                               "- 아이는 내년에" + citizenController.citizenChangePercent.youngToAdult + "% 확률로 어른이 됩니다.\n" +
                               "남성 확률 50 %, 여성 확률 50 %\n" +
                               "-아이는 내년에" + citizenController.citizenChangePercent.youngDie + "% 확률로 사망합니다.\n";
                break;
            case EPanelType.Man:
                explain.text = "-남성을 버리게 된다면 2포인트가 차감됩니다.\n" +
                               "-남성은 내년에" + citizenController.citizenChangePercent.man_take + "% 확률로 남성 혹은 여성 성인을 데려옵니다.\n" +
                               "-남성은 내년에" + citizenController.citizenChangePercent.manToOld + "% 확률로 노인이 됩니다.\n" +
                               "-남성은 내년에" + citizenController.citizenChangePercent.manDie + "% 확률로 사망합니다.";
                break;
            case EPanelType.Women:
                explain.text = "- 여성을 버리게 된다면 3포인트가 차감됩니다.\n" +
                               "- 여성은 내년에" + citizenController.citizenChangePercent.womenGenerate + "% 확률로 아이를 낳습니다.\n" +
                               "-여성은 내년에" + citizenController.citizenChangePercent.womenToOld + "% 확률로 노인이 됩니다.\n" +
                               "-여성은 내년에" + citizenController.citizenChangePercent.womenDie +"% 확률로 사망합니다.";
                break;
            case EPanelType.Old:
                explain.text = "-노인을 버리게 된다면 1포인트가 차감됩니다.\n" +
                               "- 노인은 내년에" + citizenController.citizenChangePercent.oldToDie + "% 확률로 사망합니다.";
                break;
            default:
                break;
        }
    }
}
