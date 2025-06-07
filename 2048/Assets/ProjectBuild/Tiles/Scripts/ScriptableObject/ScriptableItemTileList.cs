using UnityEngine;
using System;
using System.Collections.Generic;

public class ScriptableItemTileList : MonoBehaviour
{
    public static ScriptableItemTileList Instance { get; private set; }
    public ScriptableItemTile[] scriptableItemTiles;



    private void Awake()
    {
        Instance = this;
    }




    public ScriptableItemTile GetScriptableItemTile(int number)
    {
        foreach (var item in scriptableItemTiles)
        {
            if(item.number == number)
            {
                return item;
            }
        }

        throw new KeyNotFoundException("Object Not Found");
    }
}