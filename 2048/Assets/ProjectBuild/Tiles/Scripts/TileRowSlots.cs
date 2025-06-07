using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileRowSlots : MonoBehaviour
{
    [SerializeField] private List<TileSlot> tileSlots;
    [SerializeField] private TileBoardBase tileBoard;

    [NonSerialized] public int rowCount;

    private void Awake()
    {
        for (int i = 0; i < tileSlots.Count; i++)
        {
            tileSlots[i].rowIndex = i;
        }
    }

    public List<TileSlot> GetFreeSlots()
    {
        List<TileSlot> freeSlots = new List<TileSlot>();
        foreach (var item in tileSlots)
        {
            if (!item.IsBusy)
            {
                freeSlots.Add(item);
            }
        }

        return freeSlots;
    }

    public IEnumerator MoveLeft()
    {
        for (int i = 0; i < tileBoard.RowCount - 1; i++)
        {

            foreach (var item in tileSlots)
            {
                if (item.IsBusy)
                {
                    MoveTile(item, DirectionType.Left);
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
        tileBoard.CanMoveEnable();
    }

    public IEnumerator MoveRight()
    {
        for (int i = 0; i < tileBoard.RowCount - 1; i++)
        {
            for (int j = tileSlots.Count - 1; j >= 0; j--)
            {
                if (tileSlots[j].IsBusy)
                {
                    MoveTile(tileSlots[j], DirectionType.Right);
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
        tileBoard.CanMoveEnable();
    }




    private void MoveTile(TileSlot tileSlot, DirectionType directionType)
    {

        int colIndex = tileSlot.rowIndex;
        int numberTileScr = tileSlot.GetNumberTileScr();

        int nextSlotIndex;

        if (directionType == DirectionType.Left)
        {
            nextSlotIndex = colIndex - 1;
        }
        else if (directionType == DirectionType.Right)
        {
            nextSlotIndex = colIndex + 1;
        }
        else
        {
            throw new InvalidOperationException();
        }

        try
        {
            TileSlot nextSlot = tileSlots[nextSlotIndex];

            if (!nextSlot.IsBusy)
            {
                tileBoard.CanGenerateItem();
                tileSlot.SetNumberTileScr(null);
                nextSlot.SetNumberTileScr(numberTileScr);
            }
            else
            {
                if (nextSlot.GetNumberTileScr() == numberTileScr)
                {
                    tileBoard.CanGenerateItem();
                    int newTileScr = nextSlot.GetNumberTileScr() + numberTileScr;
                    foreach (var item in ScriptableItemTileList.Instance.scriptableItemTiles)
                    {
                        if (item.number == newTileScr)
                        {
                            nextSlot.SetNumberTileScr(newTileScr);
                        }
                    }
                    tileSlot.SetNumberTileScr(null);
                }
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }

    }

    public bool CheckTilesCanMove()
    {
        TileSlot nextSlot;

        for (int i = 0; i < tileSlots.Count - 1; i++)
        {

            nextSlot = tileSlots[tileSlots[i].rowIndex + 1];

            if (tileSlots[i].GetNumberTileScr() == nextSlot.GetNumberTileScr())
            {
                Debug.Log(tileSlots[i].rowIndex + " " + nextSlot.rowIndex);

                return true;

            }

        }

        Debug.Log("aaaaa");
        return false;
    }





}

