using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IWehicle
{
    int maxSpeed { get; }

    void Engine();
}

public class Audi : IWehicle
{
    public int maxSpeed => 300;

    public void Engine()
    {
        Debug.Log(nameof(Audi));
    }
}

public class Mersedes : IWehicle
{
    public int maxSpeed => 250;

    public void Engine()
    {
        Debug.Log(nameof(Mersedes));
    }
}

public class WehicleFactory : PlaceholderFactory<Type, IWehicle>
{
    private Dictionary<Type, IWehicle> typeWehicleDictionary = new Dictionary<Type, IWehicle>()
    {
        { typeof(Audi), new Audi() },
        { typeof(Mersedes), new Mersedes() },

    };

    public override IWehicle Create(Type param)
    {
        if(typeWehicleDictionary.TryGetValue(param, out IWehicle wehicle))
        {
            return typeWehicleDictionary[param];
        }

        throw new KeyNotFoundException(nameof(param));
    }

}


public class ZenjectFactoryTest : MonoBehaviour
{
    [Inject] private WehicleFactory wehicleFactory;


    private void Start()
    {
        IWehicle wehicle = wehicleFactory.Create(typeof(Mersedes));
        wehicle.Engine();

    }

}