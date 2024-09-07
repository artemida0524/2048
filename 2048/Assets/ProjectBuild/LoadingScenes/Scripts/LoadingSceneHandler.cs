using System.Collections;
using UnityEngine;
using Zenject;

public class LoadingSceneHandler : MonoBehaviour
{
    public static LoadingSceneHandler Instance {  get; private set; }

    private ILoadingScene loadingScene;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Inject]
    private void Construct(ILoadingScene loadingScene)
    {
        this.loadingScene = loadingScene;
    }


    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneEnumerator(index));
    }

    private IEnumerator LoadSceneEnumerator(int index)
    {
        yield return loadingScene.LoadScene();
        yield return loadingScene.FinishLoadScene(index);

    }

}
