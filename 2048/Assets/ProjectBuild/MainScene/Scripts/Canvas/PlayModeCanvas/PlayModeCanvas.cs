using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeCanvas : MonoBehaviour
{
    [SerializeField] private GameObject playModeCanvas;



    public void ClosePlayModeCanvas()
    {
        playModeCanvas.SetActive(false);
    }
}
