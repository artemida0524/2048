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

    [SerializeField] private LoadingSceneView loadingSceneView;


    private ILoadingScene loadingScene;


    public override void InstallBindings()
    {
        InstallLoadingScene();
    }

    private void InstallLoadingScene()
    {
        Container
            .Bind<ILoadingScene>()
            .FromComponentInNewPrefab(loadingSceneView)
            .AsSingle();
    }

}
