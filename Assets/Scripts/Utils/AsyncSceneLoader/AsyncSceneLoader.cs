using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{

    public void asyncLoadLobby()
    {
        StartCoroutine(LoadAsyncScene("lobbyscene"));
    }

    public void asyncLoadSample()
    {
        StartCoroutine(LoadAsyncScene("samplescene"));
    }


    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return asyncLoad.isDone;
    }
}
