using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Cell");
    }
    public void EndGame()
    {
        //first two lines so we can see it quitting while playing in unity's editor!! next two lines for actually quitting an executable game.....(weird syntax tho.....)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
        Debug.Log("Successfully quit!");
    }
}
