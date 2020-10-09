using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static private ScenesManager _inst;
    static public ScenesManager Inst
    {
        get { return _inst; }
    }

    private bool _operationDone;
    public bool operationDone
    {
        get { return _operationDone; }
    }


    private void Awake()
    {
        _inst = this;
    }


    private IEnumerator Start()
    {
        StartCoroutine(LoadScene("WelcomeScene", LoadSceneMode.Additive));
        yield return new WaitUntil(() => operationDone);
    }


    public IEnumerator LoadScene(string sceneName, LoadSceneMode mode)
    {
        _operationDone = false;
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, mode);
        yield return new WaitUntil(() => async.isDone);
        _operationDone = true;
    }


    public IEnumerator UnloadScene (string sceneName)
    {
        _operationDone = false;
        AsyncOperation async = SceneManager.UnloadSceneAsync(sceneName);
        yield return new WaitUntil(() => async.isDone);
        _operationDone = true;
    }
}
