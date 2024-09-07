using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginSceneViewDefault : MonoBehaviour, IBeginSceneView
{
    [SerializeField] private Animator animator;    


    private bool canClick = false;

    private const string BEGIN_PATH = "Begin";
    private const string CONTINUE_PATH = "Continue";

    public event Action OnClickContinue;
    public event Action OnFinishAnimation;
    public event Action OnBeginSceneView;

    public bool CanClick => canClick;
    


    public void BeginAnimation()
    {
        animator.SetTrigger(BEGIN_PATH);




        OnBeginSceneView?.Invoke();

        canClick = true;
    }

    public void ClickContinue()
    {
        OnClickContinue?.Invoke();


        animator.SetTrigger(CONTINUE_PATH);

    }

    public void FinishAnimation()
    {
        OnFinishAnimation?.Invoke();



        //SceneManager.LoadScene(2);

        LoadingSceneHandler.Instance.LoadScene(2);

    }
}
