using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class TileBoardBase : MonoBehaviour
{
    [SerializeField] private List<TileRowSlots> tileRowSlots;
    [SerializeField] private List<TileColSlots> tileColSlots;

    [SerializeField] private List<ScriptableItemTile> tileItemsScr;


    public int RowCount { get => tileRowSlots.Count; }
    public int ColCount { get => tileColSlots.Count; }

    private bool canMove = true;
    public bool CanMove => canMove;


    private bool canGenerate = false;
    public bool CanGenerate => canGenerate;




    private void Awake()
    {

        for (int i = 0; i < tileRowSlots.Count; i++)
        {
            tileRowSlots[i].rowCount = i;
        }

        for (int i = 0; i < tileColSlots.Count; i++)
        {
            tileColSlots[i].colCount = i;
        }
    }


    public void GenerateNewRandomTiles(int number)
    {

        List<TileSlot> freeSlots = GetAllFreeTile();
        int countFreeSlots = freeSlots.Count;

        if (countFreeSlots < number)
        {
            throw new InvalidOperatorException("Count number more than free slots", typeof(TileRowSlots));
        }

        for (int i = 0; i < number; i++)
        {
            countFreeSlots = freeSlots.Count;

            int randomNumber = GetRandomNumber(countFreeSlots);


            int randomTileScr = Random.Range(0, tileItemsScr.Count);

            freeSlots[randomNumber].SetNumberTileScr(ScriptableItemTileList.Instance.scriptableItemTiles[randomTileScr]);
            freeSlots.RemoveAt(randomNumber);
        }

    }
    
    public void GenerateNewRandomTiles(int number, bool canGenerateConsider)
    {
        if (canGenerate && canGenerateConsider)
        {
            GenerateNewRandomTiles(number);
        }
        canGenerate = false;
    }



    private int GetRandomNumber(int range)
    {
        return Random.Range(0, range);
    }



    public List<TileSlot> GetAllFreeTile()
    {
        List<TileSlot> tileSlots = new List<TileSlot>();

        foreach (var item in this.tileRowSlots)
        {
            tileSlots.AddRange(item.GetFreeSlots());
        }
        return tileSlots;
    }


    public IEnumerator SetDirection(DirectionType direction)
    {
        //StartCoroutine(CheckTilesCanMove());
        canGenerate = false;
        switch (direction)
        {
            case DirectionType.Up:

                if (canMove)
                {
                    canMove = false;
                    foreach (var item in tileColSlots)
                    {
                        StartCoroutine(item.MoveUp());
                    }

                    yield return new WaitForSeconds(0.5f);


                    GenerateNewRandomTiles(1, true);
                }
                yield break;


            case DirectionType.Down:
                if (canMove)
                {
                    canMove = false;
                    foreach (var item in tileColSlots)
                    {
                        StartCoroutine(item.MoveDown());
                    }

                    yield return new WaitForSeconds(0.5f);

                    GenerateNewRandomTiles(1, true);

                }
                yield break;

            case DirectionType.Left:

                if (canMove)
                {
                    canMove = false;
                    foreach (var item in tileRowSlots)
                    {
                        StartCoroutine(item.MoveLeft());
                    }

                    yield return new WaitForSeconds(0.5f);

                    GenerateNewRandomTiles(1, true);
                }
                yield break;


            case DirectionType.Right:

                if (canMove)
                {
                    canMove = false;
                    foreach (var item in tileRowSlots)
                    {
                        StartCoroutine(item.MoveRight());
                    }

                    yield return new WaitForSeconds(0.5f);

                    GenerateNewRandomTiles(1, true);
                }
                yield break;
        }

        

    }

    public void CheckTilesCanMove()
    {


        if (GetAllFreeTile().Count == 0)
        {

            bool canMoveCol = false;
            bool canMoveRow = false;

            foreach (var item in tileColSlots)
            {
                if (item.CheckTilesCanMove())
                {
                    canMoveCol = true;
                    break;
                }
            }

            foreach (var item in tileRowSlots)
            {
                if (item.CheckTilesCanMove())
                {
                    canMoveRow = true;
                    break;
                }
            }


            Debug.Log(canMoveCol + " " + canMoveRow);

            if (!canMoveCol && !canMoveRow)
            {
                LoadingSceneHandler.Instance.LoadScene(2);
                canMove = false;
            }
        }


    }

    public void CanMoveEnable()
    {
        canMove = true;
    }

    public void CanGenerateItem()
    {
        canGenerate = true;
    }

}
