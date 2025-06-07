using UnityEngine;
using Zenject;

public class AudioManager : MonoBehaviour
{
    private AudioHandler audioHandler;


    [Inject]
    private void Construct(AudioHandler audioHandler)
    {
        this.audioHandler = audioHandler;
    }

    public void ButtonClick()
    {
        audioHandler.ClickButton();
    }
}
