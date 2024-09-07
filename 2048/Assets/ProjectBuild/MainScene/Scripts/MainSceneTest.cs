using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneTest : MonoBehaviour
{
    public void OpenScene(int index)
    {
        LoadingSceneHandler.Instance.LoadScene(index);
    }
}
