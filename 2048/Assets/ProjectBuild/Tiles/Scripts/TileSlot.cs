using System;
using UnityEngine;

public class TileSlot : MonoBehaviour
{
    [SerializeField] private Tile tile;

    /*[NonSerialized] */public int colIndex;
    /*[NonSerialized] */public int rowIndex;

    //private bool isBusy = false;

    public bool IsBusy
    {
        get
        {
            return tile.IsBusy();
        }
    }


    public void SetNumberTileScr(int numberScr)
    {
        tile.SetNumber(numberScr);
    }

    public void SetNumberTileScr(ScriptableItemTile scriptableItemTile)
    {
        tile.SetNumber(scriptableItemTile);
    }
    public int GetNumberTileScr()
    {
        return tile.ScriptableTile.number;
    }



}
