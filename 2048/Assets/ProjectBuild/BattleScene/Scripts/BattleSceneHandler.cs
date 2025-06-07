using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleSceneHandler : MonoBehaviour
{
    [SerializeField] private TileBoardBase tileBoard;

    [SerializeField] private int countTile = 1;



    private void Start()
    {
        tileBoard.GenerateNewRandomTiles(countTile);
    }
}
