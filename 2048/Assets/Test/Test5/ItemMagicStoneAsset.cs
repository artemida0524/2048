using UnityEngine;

[CreateAssetMenu(fileName = "MagicStone", menuName = "Inventory/Item/MagicStone")]
public class ItemMagicStoneAsset : InventoryItemAssetBase
{

    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public int MaxLevel { get; private set; }
}
