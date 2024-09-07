using System.Collections.Generic;
using UnityEngine;
using Zenject;


public enum LoadignSceneType
{
    Default,
    //Advanced
}

public class ProjectInstallerLoadingScene : MonoInstaller
{
    

    [Space(10)]

    [SerializeField] private LoadingSceneDefault loadingSceneDefault;



    [Space(10)]

    [SerializeField] private LoadignSceneType type;



    private ILoadingScene loadingScene;
    private Dictionary<LoadignSceneType, ILoadingScene> loadingSceneDictionary;
    public override void InstallBindings()
    {
        InitializationDictionaryView();

        InstallLoadingScene();


    }

    private void InstallLoadingScene()
    {
        loadingScene = InstantiateLoadingScene(GetLoadignScene(type));

        Container
            .Bind<ILoadingScene>()
            .FromInstance(loadingScene)
            .AsSingle();
    }

    private ILoadingScene InstantiateLoadingScene(ILoadingScene loadingScene) => Container.InstantiatePrefabForComponent<ILoadingScene>(loadingScene as UnityEngine.Object);



    private void InitializationDictionaryView()
    {
        loadingSceneDictionary = new Dictionary<LoadignSceneType, ILoadingScene>()
        {
            {LoadignSceneType.Default, loadingSceneDefault },
            //{LoadignSceneType.Advanced , loadingSceneDefault },

        };
    }

    private ILoadingScene GetLoadignScene(LoadignSceneType type) => loadingSceneDictionary[type];
}
