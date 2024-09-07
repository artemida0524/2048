using System.Collections;
using System.Collections.Generic;
using Zenject;

public class ProjectInstallerPlayerData : MonoInstaller
{
    public override void InstallBindings()
    {

        Container
            .Bind<IInteractableDataPlayerPrefs>()
            .To<LoadSavePlayerData>()
            .AsCached();

        Container
            .Bind<PlayerDataService>()
            .AsSingle();

        
            
    }
}
