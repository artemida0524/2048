using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneHandler : MonoBehaviour
{
    

    public void GoToScene(int sceneId)
    {
        LoadingSceneHandler.Instance.LoadScene(sceneId);
    }
}
