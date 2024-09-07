using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.iOS;

public class DragTest : MonoBehaviour, IBeginDragHandler, IDragHandler
{

    [SerializeField] private Transform quad;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if( Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            
            if(eventData.delta.x > 0)
            {
                quad.transform.position += Vector3.right;
            }
            else
            {
                quad.transform.position += Vector3.left;
            }

        }
        else
        {

            if (eventData.delta.y > 0)
            {
                quad.transform.position += Vector3.up;
            }
            else
            {
                quad.transform.position += Vector3.down;
            }
            
        }

        Debug.Log("wefwef");
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
