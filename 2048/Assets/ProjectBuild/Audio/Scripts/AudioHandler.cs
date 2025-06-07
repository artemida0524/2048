using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [Space(10)]

    [SerializeField] private AudioClip clickButton;


    public void ClickButton()
    {
        audioSource.PlayOneShot(clickButton);
    }
}
