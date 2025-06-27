using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;

    public IInventoryItem Data { get; private set; }
    public event Action<ItemInventView> OnItemClicked;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public virtual void Init(IInventoryItem item/*, IAssetable<InventoryItemAssetBase> asset*/)
    {
        Data = item;
        //icon.sprite = item.Asset.SimpleSprite;
        text.text = item.Amount.ToString();
    }


    private void OnClick()
    {
        OnItemClicked?.Invoke(this);
    }

}

//public abstract class ItemCrabs
//{
//    public string name { get; protected set; }

//    public ItemCrabs(string name)
//    {
//        name = name;
//    }
//}

//public class InventoryItem : ItemCrabs
//{
//    public InventoryItem(string name) : base(name)
//    {
//    }
//}

//public class Rune : InventoryItem
//{
//    public int Level { get; set; }
//    public Rune(string name, int level) : base(name)
//    {
//        Level = level;
//    }
//}

//public class Card : ItemCrabs
//{
//    public int Star { get; set; }
//    public Card(string name, int star) : base(name)
//    {
//        Star = star;
//    }
//}

//public interface IItemData
//{

//}



//public class ItemDataBase<TCrabs> : IItemData where TCrabs : ItemCrabs
//{
//    public TCrabs BaseCrabs { get; protected set; }

//    public ItemDataBase(TCrabs asset)
//    {
//        BaseCrabs = asset;
//    }
//}

//public class InventoryItemDataBase<TCrabs> : ItemDataBase<TCrabs> where TCrabs : ItemCrabs
//{
//    public int Amount { get; protected set; }

//    public InventoryItemDataBase(TCrabs asset, int amount) : base(asset)
//    {
//        BaseCrabs = asset;
//        Amount = amount;

//    }
//}

//public sealed class CardItemDataBase : ItemDataBase<Card>
//{
//    public int Star { get; private set; }

//    public CardItemDataBase(Card asset, int star) : base(asset)
//    {
//        Star = star;
//    }
//}

public enum InventoryItemType
{
    Rune,
    Box,
}

public interface IItem
{
    string Name { get; }
    ItemType ItemType { get; }
}

public interface IInventoryItem : IItem
{
    int Amount { get; }
    public InventoryItemType InventoryItemType { get; }
}

public interface IDtoConvertiable
{
    ItemDto ToDto();
}

//public interface IDtoConvertiable<TDto> : IDtoConvertiable where TDto : ItemDto
//{
//    TDto ToDtoPrimitive();
//}

[Serializable]
public class ItemDto
{
    public string Name;
    public ItemType ItemType;
}

[Serializable]
public class InventoryItemDto : ItemDto
{
    public InventoryItemType InventoryItemType;
    public int Amount;
}


[Serializable]
public class RuneItemDto : InventoryItemDto
{
    public int Level;
}

[Serializable]
public class CardItemDto : ItemDto
{
    public int Star;
}




public class Item : IItem
{
    public string Name { get; protected set; }
    public ItemType ItemType { get; protected set; }

    public Item(string name, ItemType type)
    {
        Name = name;
        ItemType = type;
    }
}

public class InventoryItem : Item, IInventoryItem, IDtoConvertiable
{
    public int Amount { get; private set; }
    public InventoryItemType InventoryItemType { get; private set; }


    public InventoryItem(InventoryItemDto data) : base(data.Name, ItemType.InventoryItem)
    {
        Name = data.Name;
        ItemType = data.ItemType;
        InventoryItemType = data.InventoryItemType;
        Amount = data.Amount;
    }


    public InventoryItem(string name, InventoryItemType type, int amount) : base(name, ItemType.InventoryItem)
    {
        Amount = amount;
        InventoryItemType = type;
    }

    public virtual ItemDto ToDto()
    {
        return new InventoryItemDto
        {
            Name = Name,
            ItemType = ItemType,
            InventoryItemType = InventoryItemType,
            Amount = Amount
        };

    }
}


public sealed class ItemRune : InventoryItem
{
    public int Level { get; private set; }

    public ItemRune(RuneItemDto data) : base(data.Name, InventoryItemType.Rune, data.Amount)
    {
        Level = data.Level;

    }

    public ItemRune(string name, int amount, int level) : base(name, InventoryItemType.Rune, amount)
    {
        Level = level;
    }

    public override ItemDto ToDto()
    {
        return new RuneItemDto
        {
            Name = Name,
            ItemType = ItemType,
            InventoryItemType = InventoryItemType,
            Amount = Amount,
            Level = Level
        };

    }
}

public class ItemCard : Item, IDtoConvertiable
{
    public int Star { get; private set; }

    public ItemCard(CardItemDto data) : base(data.Name, ItemType.Card)
    {
        Name = data.Name;
        ItemType = data.ItemType;
        Star = data.Star;
    }

    public ItemCard(string name, int star) : base(name, ItemType.Card)
    {
        Star = star;
    }

        
    public virtual ItemDto ToDto()
    {
        return new CardItemDto
        {
            Name = Name,
            ItemType = ItemType,
            Star = Star
        };
    }
}