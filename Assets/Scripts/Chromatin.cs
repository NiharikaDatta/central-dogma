using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using System;


public class Chromatin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private Canvas popup;
    public StrandData strandData;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicks counted:" + eventData.clickCount);
        if(eventData.clickCount==1)
        {
            StartCoroutine(showPopup());
        }
        else if(eventData.clickCount==2)
        {
            //loadnextscene()
        }
    }
    IEnumerator showPopup()
    {
        popupText.text=strandData.proteinName;
        popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        popup.gameObject.SetActive(false);
    }
}
