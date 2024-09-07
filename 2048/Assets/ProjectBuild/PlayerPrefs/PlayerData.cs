using System;
using System.IO;
using UnityEngine;
using Zenject;

using Debug = UnityEngine.Debug;


public class LoadSavePlayerData : IInteractableDataPlayerPrefs
{
    public string PATH { get; } = "PlayerData";
    private PlayerDataService playerDataService;

    [Inject]
    public LoadSavePlayerData(PlayerDataService playerDataService)
    {
        this.playerDataService = playerDataService;
    }

    public virtual void Load()
    {
        PlayerDataDTO playerData = new PlayerDataDTO();

        if (PlayerPrefs.HasKey(PATH))
        {
            var dataJson = PlayerPrefs.GetString(PATH);

            playerData = JsonUtility.FromJson<PlayerDataDTO>(dataJson);
        }

        playerDataService.Set(playerData);


        Debug.Log("Load");
    }

    public virtual void Save()
    {
        PlayerDataDTO playerData = playerDataService.Get;
        PlayerPrefs.SetString(PATH, JsonUtility.ToJson(playerData));


        Debug.Log("Save");
    }
}


[Serializable]
public class PlayerDataDTO
{
    public string name;
}


public interface IInitializableData<T>
{
    bool CanInitializationData { get; }

    void Set(T data);
}

public class PlayerDataService : IGetDataServise<PlayerDataDTO>, IInitializableData<PlayerDataDTO>
{
    private PlayerDataDTO playerData;
    private bool canInitializationData = true;

    public PlayerDataDTO Get { get => playerData ?? throw new NullReferenceException(); }

    public bool CanInitializationData => canInitializationData;

    public void Set(PlayerDataDTO data)
    {
        if (canInitializationData)
        {
            this.playerData = data;
            canInitializationData = false;

            return;
        }

        throw new InvalidOperationException("Object Already Initialization");
    }
    //interaction

}