using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_EffectObject : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 1f;

    private void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
