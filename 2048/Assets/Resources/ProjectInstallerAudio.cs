using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectInstallerAudio : MonoInstaller
{
    [SerializeField] private AudioHandler audioHandler;

    public override void InstallBindings()
    {

        Container
            .Bind<AudioHandler>()
            .FromComponentInNewPrefab(audioHandler)
            .AsSingle();

    }

}
