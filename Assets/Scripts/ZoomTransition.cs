using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomTransition : MonoBehaviour
{
    public Animator blackhole;
    public float doubleclick=0.3f;
    public float lastclick=0f;
  void OnMouseDown()
  {
    float timelastclick=Time.time - lastclick; //finding difference bw lastclick time and current time
    if(timelastclick<=doubleclick)
        {
            OnNucleusDoubleClick();
        }
    else
        {
            lastclick=Time.time; //setting last click time to the latest click
            OnNucleusSingleClick();

        }
  }
  public void OnNucleusDoubleClick()
    {
        Debug.Log("Nucleus is Double Clicked!!");
        Vector3 screenclickpos=Camera.main.WorldToScreenPoint(transform.position); //position of nucleus at that point and converting into screen pos to play the animation from there
        RectTransform blackrect=blackhole.GetComponent<RectTransform>(); //getting pos of the animator component itself...
        if(blackrect!=null)
        {
            blackrect.position=screenclickpos; //changing position of animator to start at correct place...
        }
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        blackhole.SetTrigger("Start"); //play animation
        yield return new WaitForSeconds(1f); //wait
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
    }
    public void OnNucleusSingleClick()
    {
        Debug.Log("Welcome to Central Dogma!!");
    }
}
