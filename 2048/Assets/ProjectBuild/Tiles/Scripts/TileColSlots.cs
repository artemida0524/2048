using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TileColSlots : MonoBehaviour
{

    [SerializeField] private TileBoardBase tileBoard;

    public List<TileSlot> tileSlots;

    [NonSerialized] public int colCount;

    private void Awake()
    {
        for (int i = 0; i < tileSlots.Count; i++)
        {
            tileSlots[i].colIndex = i;
        }
    }

    public IEnumerator MoveUp()
    {

        for (int i = 0; i < tileBoard.ColCount - 1; i++)
        {

            foreach (var item in tileSlots)
            {
                if (item.IsBusy)
                {
                    MoveTile(item, DirectionType.Up);
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
        tileBoard.CanMoveEnable();
    }

    public IEnumerator MoveDown()
    {
        for (int i = 0; i < tileBoard.ColCount - 1; i++)
        {
            for (int j = tileSlots.Count - 1; j >= 0; j--)
            {
                if (tileSlots[j].IsBusy)
                {
                    MoveTile(tileSlots[j], DirectionType.Down);
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
        tileBoard.CanMoveEnable();
    }

    private void MoveTile(TileSlot tileSlot, DirectionType directionType)
    {
        int colIndex = tileSlot.colIndex;
        int numberTileScr = tileSlot.GetNumberTileScr();

        int nextSlotIndex;

        if (directionType == DirectionType.Up)
        {
            nextSlotIndex = colIndex - 1;
        }
        else if (directionType == DirectionType.Down)
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

            nextSlot = tileSlots[tileSlots[i].colIndex + 1];

            if (tileSlots[i].GetNumberTileScr() == nextSlot.GetNumberTileScr())
            {
                Debug.Log(tileSlots[i].colIndex + " " + nextSlot.colIndex);

                return true;

            }

        }

        Debug.Log("aaaaa");
        return false;
    }

}
