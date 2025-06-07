using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image tileImage;

    [SerializeField] private CanvasGroup canvasGroup;

    public ScriptableItemTile scriptableTile;

    public ScriptableItemTile ScriptableTile
    {
        get
        {
            return scriptableTile;
        }
        private set
        {
            
            if(value == null)
            {
                canvasGroup.alpha = 0;
                scriptableTile = value;

                return;
            }

            if (scriptableTile == null)
            {
                canvasGroup.alpha = 1;
            }

            tileImage.color = value.color;

            icon.sprite = value.sprite;


            scriptableTile = value;
        }
    }


    public void SetNumber(int number)
    {
        ScriptableTile = ScriptableItemTileList.Instance.GetScriptableItemTile(number);
    }

    public void SetNumber(ScriptableItemTile scriptableItemTile)
    {
        ScriptableTile = scriptableItemTile;
    }

    public void SetZeroNumber()
    {
        ScriptableTile = null;
    }

    public bool IsBusy() => scriptableTile != null;


}
