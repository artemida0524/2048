using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ItemDataCollection : MonoBehaviour
{
    [field: SerializeField] public List<ItemAssetBase> InventoryItemsAssets { get; private set; }
    public List<ItemCard> CardsItems { get; private set; } = new List<ItemCard>();

    public Dictionary<InventoryItemType, List<IInventoryItem>> InventoryItems = new();


    private void Awake()
    {
        Init();
    }

    private void Init()
    {

        string json = SimulateGetData();

        ItemDtoList itemDtoList = JsonConvert.DeserializeObject<ItemDtoList>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        foreach (var itemDto in itemDtoList.itemDtos)
        {
            if (itemDto is RuneItemDto runeDto)
            {
                ItemRune newItem = new ItemRune(runeDto);
                AddInventoryItem(newItem);
            }
            else if (itemDto is CardItemDto cardDto)
            {
                ItemCard card = new ItemCard(cardDto);
                CardsItems.Add(card);
            }
            else if (itemDto is InventoryItemDto inventoryItemDto)
            {
                InventoryItem inventoryItem = new InventoryItem(inventoryItemDto.Name, inventoryItemDto.InventoryItemType, inventoryItemDto.Amount);
                AddInventoryItem(inventoryItem);
            }
        }

        //foreach (var item in InventoryItemsAssets.OfType<ItemRuneAsset>())
        //{
        //    ItemRune newItem = new ItemRune(item.Name, 34, 34);
        //    AddInventoryItem(newItem);
        //}
        //foreach (var item in InventoryItemsAssets.OfType<ItemRuneAsset>())
        //{
        //    ItemRune newItem = new ItemRune(item.Name, 34, 34);
        //    AddInventoryItem(newItem);
        //}

        //foreach (var item in InventoryItemsAssets.OfType<ItemCardAsset>())
        //{
        //    ItemCard card = new ItemCard(item.Name, 1);
        //    CardsItems.Add(card);
        //}
    }


    public IEnumerable<IInventoryItem> GetInventoryItemsByType(InventoryItemType type)
    {
        if (InventoryItems.TryGetValue(type, out var items))
        {
            return items;
        }
        return Enumerable.Empty<IInventoryItem>();
    }

    public IEnumerable<IInventoryItem> GetAllInventoryItem()
    {
        foreach (var keyValue in InventoryItems)
        {
            foreach (var item in keyValue.Value)
            {
                yield return item;
            }
        }
    }


    private void AddInventoryItem(IInventoryItem item)
    {
        if (!InventoryItems.ContainsKey(item.InventoryItemType))
        {
            InventoryItems[item.InventoryItemType] = new List<IInventoryItem>();
        }
        InventoryItems[item.InventoryItemType].Add(item);
    }



    private string SimulateGetData()
    {
        List<ItemDto> dtos = new List<ItemDto>();

        foreach (var item in InventoryItemsAssets.OfType<ItemRuneAsset>())
        {
            ItemRune newItem = new ItemRune(item.Name, 34, 34);
            dtos.Add(newItem.ToDto());
        }

        foreach (var item in InventoryItemsAssets.OfType<ItemCardAsset>())
        {
            ItemCard card = new ItemCard(item.Name, 1);
            dtos.Add(card.ToDto());
        }

        InventoryItem inventoryItem = new InventoryItem("TestInventoryItem", InventoryItemType.Rune, 10);

        dtos.Add(inventoryItem.ToDto());

        ItemDtoList itemDtoList = new ItemDtoList
        {
            itemDtos = dtos.ToArray()
        };

        return JsonConvert.SerializeObject(itemDtoList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
    }

}
