public interface ILoadDataPlayerPrefs
{
    string PATH { get; }
    void Load();
}

public interface IGetDataServise<T>
{
    T Get { get; }
}

public interface ISaveDataPLayerPrefs
{
    void Save();
}

public interface IInteractableDataPlayerPrefs : ILoadDataPlayerPrefs, ISaveDataPLayerPrefs
{
    
}