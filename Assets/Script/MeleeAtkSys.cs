using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtkSys : MonoBehaviour
{
    [SerializeField] [Header("Range of melee")]private float atkRage = .5f;

    [Header("Point that circle of atack is created")]public GameObject atackPoint;
    [Header("LayerMask that combine enemy")]public LayerMask enermyLayer;
    public int _combo=1;
    public int maxCombo=6;
    public bool _atk=false;
    private float Bonusdame;
    public Animator _anim;
    public Player player;
    public SoundManager soundManager;
   [SerializeField] private GameObject hitEffect;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetButtonDown("MeleeAtack"))
        {
            Combo();
        }
        else
        {
           if(Input.anyKey&& !Input.GetButton("MeleeAtack")){
                _atk = false;
                _combo = 0;   
            }
                
        }
            
    }
    public void Melee(float dame)
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(atackPoint.transform.position, atkRage, enermyLayer);
        if (col != null)
        {
            foreach (Collider2D enemy in col)
            {
                Debug.Log("atack " + enemy.name + " " + dame);
                enemy.GetComponent<Enemy>().takeDamage(dame);
                Instantiate(hitEffect, enemy.transform.position, Quaternion.identity);
               //I will make that change when again many enermy
                soundManager.PlaySound("hit");
            }
           
        }
            
    }

    public void Start_Combo()
    {
        _atk = false;
        if (_combo < maxCombo)
        {
            _combo++;
             Melee(player.GetAtk());
        }
        else
        {
            if (_combo == maxCombo)
            {
                Melee(player.GetAtk()*2);
                _combo = 0;
            }                  
        }
        soundManager.PlaySound("slash");
    }
    public void FinshCombo()
    {
        _atk = false;
        _combo = 0;
    }
    public void Combo()
    {
        if (Input.GetButtonDown("MeleeAtack") && !_atk)
        {
            //avoid combo zero
            if (_combo == 0)
            {
                _combo++;
            }
                _anim.SetTrigger("combo" + _combo);

                _atk = true;
    
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
