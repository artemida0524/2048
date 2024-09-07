using System;
using System.Collections;
using UnityEngine;

public interface ILoadingScene
{
    float WaitBeforeLoading { get; }

    IEnumerator StartLoading();
    IEnumerator LoadScene();
    IEnumerator FinishLoadScene(int index);
}
