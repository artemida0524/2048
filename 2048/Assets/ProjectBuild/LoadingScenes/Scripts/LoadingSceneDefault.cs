using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneDefault : MonoBehaviour, ILoadingScene
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image imageLoading;

    [SerializeField] private float waitBeforeLoading = 0.5f;
    [SerializeField] private float waitPerLoading = 0.3f;

    private const string START_LOADING_PATH = "StartLoading";
    private const string FINISH_LOADING_PATH = "FinishLoading";

    private float fillAmount = 0f;
    //////////////////////////////
    private float fillAmountBegin;

    
    public float WaitBeforeLoading => waitBeforeLoading;

    private void Awake()
    {
        InitializationBeginingVariable();
    }

    private void InitializationBeginingVariable()
    {
        fillAmountBegin = fillAmount;
    }

    public IEnumerator LoadScene()
    {
        Debug.Log("LoadScene");
        yield return StartLoading();

        while (this.fillAmount <= 1f)
        {
            Debug.Log("wfwf");
            imageLoading.fillAmount = this.fillAmount += 0.2f;
            yield return new WaitForSeconds(waitPerLoading);
        }
    }

    public IEnumerator FinishLoadScene(int index)
    {
        SceneManager.LoadScene(index);



        animator.SetTrigger(FINISH_LOADING_PATH);



        UpdateBackData();
        yield return null;
    }



    public IEnumerator StartLoading()
    {
        animator.SetTrigger(START_LOADING_PATH);

        yield return new WaitForSeconds(WaitBeforeLoading);
    }


    private void UpdateBackData()
    {
        fillAmount = fillAmountBegin;
    }
}
