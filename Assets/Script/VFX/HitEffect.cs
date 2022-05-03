using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect: MonoBehaviour 
{
    private void Awake()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward *Random.Range(0,360));
    }
    public void DestroyHit()
    {
        Destroy(gameObject);
    }

}
