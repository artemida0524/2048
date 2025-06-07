using Zenject;

public class ProjectInstallerGameInfo : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<InfoBattleScene>()
            .AsSingle();
    }
}
