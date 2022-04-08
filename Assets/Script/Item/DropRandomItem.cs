using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRandomItem : MonoBehaviour
{
    public GameObject[] _prefab;
    public int[] _prefabChance;

    public GameObject SelectItem()
    {
        // Calculate the summa of all portions.
        int poolSize = 0;
        for (int i = 0; i < _prefab.Length; i++)
        {
            // poolSize += items[i].chance;
            poolSize += _prefabChance[i];
        }

        // Get a random integer from 0 to PoolSize.
        // int randomNumber = rnd.Next(0, poolSize) + 1;
        int randomNumber = Random.Range(0, poolSize) + 1;

        // Detect the item, which corresponds to current random number.
        int accumulatedProbability = 0;
        for (int i = 0; i < _prefab.Length; i++)
        {
            // accumulatedProbability += items[i].chance;
            accumulatedProbability += _prefabChance[i];
            if (randomNumber <= accumulatedProbability)
                return _prefab[i];
        }
        return null;    // this code will never come while you use this programm right :)
    }


    public void dropRandomItem()
    {
        // int pos = Random.Range(0, _prefab.Length);
        // Debug.Log("Drop item at pos " + pos + " has lenght : " + _prefab.Length);

        Instantiate(SelectItem(), gameObject.GetComponentInParent<Transform>().position, Quaternion.identity);
    }
}
