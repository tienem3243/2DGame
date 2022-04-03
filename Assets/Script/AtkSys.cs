using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSys : MonoBehaviour
{
    [SerializeField] [Header("Range of melee")]private float atkRage = .5f;

    [Header("Point that circle of atack is created")]public GameObject atackPoint;
    [Header("LayerMask that combine enemy")]public LayerMask enermyLayer;
    public int _combo=1;
    public int maxCombo=6;
    public bool _atk=false;
    private float Bonusdame;
    public Animator _anim;
    private void Update()
    {
        if (Input.GetButtonDown("MeleeAtack"))
        {
            Combo();
        }
        else
        {
           if(Input.anyKeyDown&& !Input.GetButtonDown("MeleeAtack")){
                _atk = false;
                _combo = 1;   
            }
                
        }
            
    }
    public void Melee(int dame)
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(atackPoint.transform.position, atkRage, enermyLayer);
        if (col != null)
            foreach (Collider2D enemy in col)
            {
                Debug.Log("atack " + enemy.name + " " + dame);
                enemy.GetComponent<Enemy>().takeDamage(dame);
            }
    }

    public void Start_Combo()
    {
       
        _atk = false;
        if (_combo < maxCombo)
        {
            _combo++;
             Melee(20);
        }
        else
        {
            if (_combo == maxCombo)
            {
                Melee(40);//todo Need scale with total stat of player
            }        
            _combo = 1;
        }
        
    }
    public void FinshCombo()
    {
        _atk = false;
        _combo = 1;
    }
    public void Combo()
    {
        if (Input.GetButtonDown("MeleeAtack")&&!_atk)
        {
            _atk = true;
            _anim.SetTrigger("combo" + _combo);
            Debug.Log(_combo);
        }
    }

    //gizmos draw range of atk

    void OnDrawGizmosSelected()
    {
        if (atackPoint != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(atackPoint.gameObject.transform.position, atkRage);
           
        }
    }

}