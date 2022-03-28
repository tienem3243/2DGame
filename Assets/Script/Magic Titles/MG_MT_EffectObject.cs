using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_MT_EffectObject : MonoBehaviour
{
    public float lifeTime = 1f;

    private void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
