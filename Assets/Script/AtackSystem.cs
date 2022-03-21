using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackSystem : MonoBehaviour
{
    [SerializeField]
    private float atkRage=.1f;
    public GameObject atkPoint;
    public LayerMask enermyLayer;
    
    public void Melee(int dame)
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(atkPoint.transform.position,atkRage,enermyLayer);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].gameObject != gameObject)
            {
                //dame
                Debug.Log("Hit " + col[i].gameObject.name+" "+dame);
            }
        }
    }

}
