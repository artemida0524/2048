using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestSceeneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.BindFactory<Type, IWehicle, WehicleFactory>()
            .FromFactory<WehicleFactory>();

    }
}
