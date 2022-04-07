using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRandomItem : MonoBehaviour
{
    // public static DropRandomItem _instance;
    public GameObject[] _prefab;
    // public int[] _prefabCount;
    /*
    private void Start()
    {
        _instance = this;
    }
    */

    public void dropRandomItem()
    {
        /*
    i       1    2   3
    obj     A    B   C
    rate    50%  30% 20%
        
    Random (1 -> 3): 1, 2, 3

    Create List manager all prefab, and mixing it.
    
    For: loop all prefab
        For: add all ID prefab with the prefabCount into list
        */
        // List<int> list = new List<int>();
        // for (int i = 0; i < _prefabCount.Length; i++)
        // {
        //     for (int j = 1; j < _prefabCount[i]; j++)
        //     {
        //         list.Add(i);
        //     }
        // }

        // Random.Range(0, )
        // list.random


        int pos = Random.Range(0, _prefab.Length);
        Debug.Log("Drop item at pos " + pos + " has lenght : " + _prefab.Length);

        Instantiate(_prefab[pos], gameObject.GetComponentInParent<Transform>().position, Quaternion.identity);
    }
}
