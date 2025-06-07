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
        Debug.Log("Inject");
        this.view = view;
    }


    private IEnumerator Start()
    {

        yield return null;
        Debug.Log("BeginAnimation");
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
