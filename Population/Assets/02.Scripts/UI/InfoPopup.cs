using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject popup = null;

    private float applyHeight = 0f;

    [SerializeField]
    private RectTransform image = null;

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
        popup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        popup.SetActive(false);
    }

}
