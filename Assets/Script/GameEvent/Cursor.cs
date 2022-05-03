using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private bool col;

    public bool getCollider()
    {
        return col;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        col = true;
    }
    private void OnTriggerExit(Collider other)
    {
        col = false;
    }
}
