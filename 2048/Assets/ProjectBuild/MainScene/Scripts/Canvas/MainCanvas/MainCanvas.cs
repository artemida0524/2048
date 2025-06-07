using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private GameObject playModeCanvas;


    public void OpenPlayModeCanvas()
    {
        playModeCanvas.SetActive(true);
    }

}
