using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainSceneTest : MonoBehaviour
{
    //private PLayerDataServiceConfig pLayerDataServiceConfig;


    //[Inject]
    //private void Construct(PLayerDataServiceConfig pLayerDataServiceConfig)
    //{
    //    this.pLayerDataServiceConfig = pLayerDataServiceConfig;
    //    Debug.Log(pLayerDataServiceConfig);
    //}

    public void OpenScene(int index)
    {
        LoadingSceneHandler.Instance.LoadScene(index);

        //Debug.Log(pLayerDataServiceConfig);
    }



}
