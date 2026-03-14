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
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
        Debug.Log("Successfully quit!");
    }
}
