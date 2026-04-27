using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderService
{
    public static IEnumerator LoadAsync(int index)
    {
        AsyncOperation waitLoading = SceneManager.LoadSceneAsync(index);

        yield return new WaitUntil(() => waitLoading.isDone);
    }
}
