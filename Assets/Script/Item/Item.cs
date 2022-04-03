using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject//, IPointerDownHandler
{
    public string itemName;
    public string itemDes;


    public Sprite itemSprite;
    public int itemPrice;

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     // throw new System.NotImplementedException();
    //     Debug.Log("On Pointer Down");
    // }
}
