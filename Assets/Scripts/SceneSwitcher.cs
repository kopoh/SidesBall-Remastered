using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Image loadingImg;
 
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        //StartCoroutine(AsyncLoad(SceneName));
    }

    IEnumerator AsyncLoad(string SceneName) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            yield return null;
        }
    }

    public void LoadURL(string url)
    {
        Application.OpenURL(url);
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif
    }
}
