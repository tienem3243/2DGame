using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSys : MonoBehaviour
{
    [SerializeField] private float atkRage = .5f;

    public GameObject atackPoint;
    public LayerMask enermyLayer;

    public void Melee(int dame)
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(atackPoint.transform.position, atkRage, enermyLayer);
        if (col != null)
            foreach (Collider2D enemy in col)
            {
                Debug.Log("atack " + enemy.name + " " + dame);
                enemy.GetComponent<Enemy>().takeDamage(20);
            }
    }
}
