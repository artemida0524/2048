using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public enum DirectionType
{
    Up,
    Down,
    Left,
    Right
}

public class InputBattleScene : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private TileBoardBase tileBoard;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                StartCoroutine(tileBoard.SetDirection(DirectionType.Right));
                StartCoroutine(enumerator());
                return;
            }
            else
            {
                StartCoroutine(tileBoard.SetDirection(DirectionType.Left));
                StartCoroutine(enumerator());
                return;
            }
            
        }
        else
        {

            if (eventData.delta.y > 0)
            {
                StartCoroutine(tileBoard.SetDirection(DirectionType.Up));
                StartCoroutine(enumerator());
                return;
            }
            else
            {
                StartCoroutine(tileBoard.SetDirection(DirectionType.Down));
                StartCoroutine(enumerator());
                return;
            }
            

        }
        

    }

    public void OnDrag(PointerEventData eventData)
    {

    }


    private IEnumerator enumerator()
    {

        yield return new WaitForSeconds(0.6f);

        tileBoard.CheckTilesCanMove();
    }
}
