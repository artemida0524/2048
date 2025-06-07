using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum BeginSceneType
{
    Default,
    Advanced
}


public class BeginSceneInstaller : MonoInstaller
{
    [SerializeField] private BeginSceneViewDefault beginSceneViewDefault;
    [SerializeField] private BeginSceneViewAdvanced beginSceneViewAdvanced;
    //

    [Space(10)]

    [SerializeField] private BeginSceneType type;

    private IBeginSceneView view;
    private Dictionary<BeginSceneType, IBeginSceneView> viewDictionary;


    public override void InstallBindings()
    {
        InitializationDictionaryView();

        // код з warning
        view = GetView(type);


        Container
                .Bind<IBeginSceneView>()
                .FromComponentInNewPrefab(view as Object)
                .AsSingle()
                .NonLazy();
    }

    private IBeginSceneView InstantiateView(IBeginSceneView view) => Container.InstantiatePrefabForComponent<IBeginSceneView>(view as UnityEngine.Object);



    private void InitializationDictionaryView()
    {
        viewDictionary = new Dictionary<BeginSceneType, IBeginSceneView>()
        {
            {BeginSceneType.Default, beginSceneViewDefault },
            {BeginSceneType.Advanced, beginSceneViewAdvanced },

        };
    }

    private IBeginSceneView GetView(BeginSceneType type) => viewDictionary[type];
}
