using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleSceneInstaller : MonoInstaller
{
    [SerializeField] private TileBoard4x4 tileBoard4X4;
    


    //private InfoBattleScene infoBattleScene;

    //[Inject]
    //private void Construct(InfoBattleScene infoBattleScene)
    //{
    //    this.infoBattleScene = infoBattleScene;

    //    Debug.Log(infoBattleScene.tableType);
    //}

    //public override void InstallBindings()
    //{
    //    if(infoBattleScene.tableType == TableType.x4x4)
    //    {
    //        Container
    //            .Bind<TileBoardBase>()
    //            .To<TileBoard4x4>()
    //            .FromComponentInNewPrefab(tileBoard4X4)
    //            .AsSingle();
    //    }
    //}
}
