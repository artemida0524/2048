using UnityEngine;

[CreateAssetMenu(fileName = "CardAsset", menuName = "Inventory/Item/CardAsset")]
public class ItemCardAsset : ItemAssetBase
{
    [field: SerializeField] public Sprite FirstStar { get; private set; }
    [field: SerializeField] public Sprite SecondStar { get; private set; }
    [field: SerializeField] public Sprite ThirdStar { get; private set; }
}
