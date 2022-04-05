using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("On Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("On Drag");
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("On Drop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("On end Drag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("On Pointer Click" + eventData.clickCount);

        // Debug.Log("Get obj : " + eventData)

        if (eventData.clickCount == 2)
        {
            ItemManager.instance.removeItem(1);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("On Pointer Down");
    }
}
