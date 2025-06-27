using UnityEngine;

public abstract class ItemAssetBase : ScriptableObject
{
    [field: SerializeField] public string Name { get; protected set; }
}
