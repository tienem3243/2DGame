using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRandomItem : MonoBehaviour
{
    public static DropRandomItem _instance;
    public Item[] _prefab;

    private void Start()
    {
        _instance = this;
    }

    public void dropRandomItem()
    {
        int pos = Random.Range(0, _prefab.Length);
        Instantiate(_prefab[pos], gameObject.transform.position, Quaternion.identity);
    }
}
