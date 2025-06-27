using UnityEngine;

[CreateAssetMenu(fileName = "RuneAsset", menuName = "Inventory/Item/RuneAsset")]
public class ItemRuneAsset : InventoryItemAssetBase
{

    [field: SerializeField] public Sprite FirstLevel { get; private set; }
    [field: SerializeField] public Sprite SecondLevel { get; private set; }
    [field: SerializeField] public Sprite ThirdLevel { get; private set; }
}
