using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVisible : MonoBehaviour
{
    Color color;
    private void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        color.a = 1;
        this.GetComponent<SpriteRenderer>().color = color;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        color.a = 0;
        this.GetComponent<SpriteRenderer>().color = color;

    }
   
 
}

