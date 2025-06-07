using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Tile", menuName = "Tile")]
public class ScriptableItemTile : ScriptableObject
{
    public int number;
    public Sprite sprite;

    public Color color;
}
