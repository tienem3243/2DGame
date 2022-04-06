using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRandomItem : MonoBehaviour
{
    // public static DropRandomItem _instance;
    public GameObject[] _prefab;

    /*
    private void Start()
    {
        _instance = this;
    }
    */

    public void dropRandomItem()
    {
        int pos = Random.Range(0, _prefab.Length);
        Debug.Log("Drop item at pos " + pos + " has lenght : " + _prefab.Length);

        Instantiate(_prefab[pos], gameObject.GetComponentInParent<Transform>().position, Quaternion.identity);
    }
}
