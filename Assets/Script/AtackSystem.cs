using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackSystem : MonoBehaviour
{
    [SerializeField]
    private float atkRage=.5f;
    public GameObject atkPoint;
    public LayerMask enermyLayer;
    
    public void Melee(int dame)
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(atkPoint.transform.position,atkRage,enermyLayer);
        if(col!=null)
            foreach (Collider2D enemy in col)
            {
                Debug.Log("atack "+enemy.name + " " + dame);
                enemy.GetComponent<Enemy>().takeDamage(20);
            }
    }
    private void OnDrawGizmosSelected()
    {
        if (atkPoint = null) return;
        Gizmos.DrawWireSphere(atkPoint.transform.position, atkRage);
    }

}
