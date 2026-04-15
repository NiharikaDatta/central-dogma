using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using System;
using UnityEngine.SceneManagement;


public class Chromatin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private Canvas popup;
    public StrandData strandData;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject StrandUnravel;
    [SerializeField] private GameObject chromatin;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicks counted:" + eventData.clickCount);
        if(eventData.clickCount==1)
        {
            StartCoroutine(showPopup());
        }
        else if(eventData.clickCount==2)
        {
            Vector3 screenclickpos=Camera.main.WorldToScreenPoint(transform.position);
            RectTransform rectTransform=animator.GetComponent<RectTransform>();
            if(animator!=null)
            {
                rectTransform.position=screenclickpos;
            }
            StartCoroutine(loadNextScene());
        }
    }
    IEnumerator showPopup() 
    {
        popupText.text=strandData.proteinName;
        popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        popup.gameObject.SetActive(false);
    }
    IEnumerator loadNextScene()
    {
        PlayerPrefs.SetString("SelectedStrand", strandData.name);
        PlayerPrefs.Save();
        chromatin.SetActive(false);
        StrandUnravel.SetActive(true);
        animator.SetTrigger("StrandUnravel");
        yield return new WaitForSeconds(1f);
        StrandUnravel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}