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
}
