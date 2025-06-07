using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootStrap : MonoBehaviour
{
    private IInteractableDataPlayerPrefs[] playerPrefs;
    private PlayerDataService playerDataService;

    public event Action OnInitialization;


    ////
    private LoadSavePlayerDataBase[] playerData;
    ///

    //[Inject]
    //private void Construct(IInteractableDataPlayerPrefs[] playerPrefs, PlayerDataService playerDataService)
    //{
    //    this.playerPrefs = playerPrefs;
    //    this.playerDataService = playerDataService;
    //}


    [Inject]
    private void Construct(LoadSavePlayerDataBase[] playerData)
    {
        this.playerData = playerData;
    }

    private void Start()
    {
        OnInitialization += InitializationDataFromPlayerPrefs;

        OnInitialization?.Invoke();



        //Application.quitting += SaveDataFromServices;

        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(new PlayerDataDTO() { name = "Nigger" }));


        GoToNextScene();
    }


    private void InitializationDataFromPlayerPrefs()
    {
        //foreach (var item in playerPrefs)
        //{
        //    item.Load();
        //}

        //foreach (var item in playerData)
        //{
        //    item.Load();
        //}

    }


    private void SaveDataFromServices()
    {
        foreach (var item in playerPrefs)
        {
            item.Save();
        }
    }



    private void GoToNextScene()
    {
        SceneManager.LoadScene(1);
    }
}