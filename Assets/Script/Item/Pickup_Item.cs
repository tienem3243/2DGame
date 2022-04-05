using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup_Item : MonoBehaviour
{
    public Item _itemData;

    private void Start()
    {
        Physics.IgnoreLayerCollision(0, 8);
        gameObject.GetComponent<SpriteRenderer>().sprite = _itemData.itemSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player get : " + _itemData.itemName);
            ItemManager.instance.addItem(_itemData);

            Destroy(gameObject);
        }
    }

    //Detect when there is a collision
    // void OnCollisionStay(Collision collide)
    // {
    //     //Output the name of the GameObject you collide with
    //     Debug.Log("I hit the GameObject : " + collide.gameObject.name);
    //     if (collide.gameObject.tag == "Player")
    //     {
    //         Debug.Log("Player get : " + _itemData.itemName);
    //     }
    // }

}
