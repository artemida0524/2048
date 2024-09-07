using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootStrap : MonoBehaviour
{
    private IInteractableDataPlayerPrefs[] playerPrefs;
    private PlayerDataService playerDataService;

    public event Action OnInitialization;

    [Inject]
    private void Construct(IInteractableDataPlayerPrefs[] playerPrefs, PlayerDataService playerDataService)
    {
        this.playerPrefs = playerPrefs;
        this.playerDataService = playerDataService;
    }

    private void Start()
    {
        OnInitialization += InitializationDataFromPlayerPrefs;

        OnInitialization?.Invoke();



        //Application.quitting += SaveDataFromServices;




        GoToNextScene();
    }


    private void InitializationDataFromPlayerPrefs()
    {
        foreach (var item in playerPrefs)
        {
            item.Load();
        }
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