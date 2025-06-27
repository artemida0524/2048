using UnityEngine;

public abstract class InventoryItemAssetBase : ItemAssetBase
{
    [field: SerializeField] public Sprite SimpleSprite { get; private set; }
}