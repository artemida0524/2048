using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BeginSceneInitializator : MonoBehaviour
{
    private IBeginSceneView view;


    [Inject]
    private void Construct(IBeginSceneView view)
    {
        this.view = view;
    }


    private void Start()
    {
        view.BeginAnimation();
    }




    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && view.CanClick)
        {
            view.ClickContinue();
        }
    }
}
