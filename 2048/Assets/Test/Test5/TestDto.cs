using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemDtoList
{
    public ItemDto[] itemDtos;
}

public class TestDto : MonoBehaviour
{
    private List<ItemDto> itemDtos = new();
    public ItemDataCollection itemDataCollection;

    private void Start()
    {
        foreach (var item in itemDataCollection.InventoryItems)
        {
            foreach (var inventoryItem in item.Value)
            {
                if (inventoryItem is IDtoConvertiable dto)
                {
                    itemDtos.Add(dto.ToDto());
                }
            }   
        }

        ItemDtoList itemDtoList = new ItemDtoList
        {
            itemDtos = itemDtos.ToArray()
        };

        string json = JsonConvert.SerializeObject(itemDtoList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        Debug.Log(json);

        ItemDtoList list = JsonConvert.DeserializeObject<ItemDtoList>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        foreach (var item in list.itemDtos)
        {
            Debug.Log(item.GetType());
        }

    }

}