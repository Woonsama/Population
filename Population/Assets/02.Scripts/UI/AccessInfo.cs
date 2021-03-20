using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccessInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform infomation;

    private bool doing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (doing)
            return;

        StartCoroutine("showInfo");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if (doing)
        //    return;
        StopCoroutine("popupOpen");
        StartCoroutine("hideInfo");
    }

    IEnumerator showInfo()
    {
        doing = true;
        Vector3 infoPos = infomation.localPosition;

        while (infoPos.x > -180f)
        {
            infoPos.x -= 8f;
            infomation.localPosition = infoPos;
            yield return null;
        }

        infoPos.x = -180f;
        infomation.localPosition = infoPos;
        doing = false;
    }

    IEnumerator hideInfo()
    {
        doing = true;
        Vector3 infoPos = infomation.localPosition;

        while (infoPos.x < -140f)
        {
            infoPos.x += 8f;
            infomation.localPosition = infoPos;
            yield return null;
        }

        infoPos.x = -140f;
        infomation.localPosition = infoPos;
        doing = false;
    }
}
