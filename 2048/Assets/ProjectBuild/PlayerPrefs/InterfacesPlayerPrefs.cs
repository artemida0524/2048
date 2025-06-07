using UnityEngine;
using Zenject;

public interface ILoadDataPlayerPrefs
{
    string PATH { get; }
    void Load();
}

public interface IGetDataServise<T>
{
    T Get { get; }
}

public interface ISaveDataPLayerPrefs
{
    void Save();
}

public interface IInteractableDataPlayerPrefs : ILoadDataPlayerPrefs, ISaveDataPLayerPrefs
{

}



public abstract class LoadSavePlayerDataBase : IInteractableDataPlayerPrefs
{
    public abstract string PATH { get; }
    public  PlayerDataDTOBase playerDataDTO { get; protected set; }
    public  IPlayerDataService playerDataService { get; protected set; }

    public virtual void Load()
    {
        //IPlayerDataDTO playerData;

        if (PlayerPrefs.HasKey(PATH))
        {
            var dataJson = PlayerPrefs.GetString(PATH);
            Debug.Log(dataJson);

            playerDataDTO = JsonUtility.FromJson<PlayerDataDTOBase>(dataJson);

            playerDataService.Set(playerDataDTO);
        }
    }

    public virtual void Save()
    {
        throw new System.NotImplementedException();
    }


    protected void InitializePlayerDataDTO(PlayerDataDTOBase playerDataDTO, IPlayerDataService playerDataService)
    {
        this.playerDataDTO = playerDataDTO;
        this.playerDataService = playerDataService;
    }
}


//public class LoadSavePlayerDataConfig : LoadSavePlayerDataBase
//{
//    public override string PATH { get; } = "PlayerData";

//    private PLayerDataServiceConfig playerDataServiceConfig;

//    //public override IPlayerDataDTO playerDataDTO { get; protected set; }
//    //public override IPlayerDataService playerDataService { get; protected set; }

//    [Inject]
//    private void Construct(PLayerDataServiceConfig playerDataServiceConfig)
//    {
//        this.playerDataServiceConfig = playerDataServiceConfig;
//        Debug.Log((playerDataServiceConfig.Get as PlayerDataDTO).name);
//    }

//    public override void Load()
//    {
//        base.InitializePlayerDataDTO(new PlayerDataDTO(), playerDataServiceConfig);


//        base.Load();
//        //Debug.Log(playerDataDTO.GetType() + " " + playerDataService.GetType());
//    }
//}