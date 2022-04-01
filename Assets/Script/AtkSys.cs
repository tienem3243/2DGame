using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSys : MonoBehaviour
{
    [SerializeField] private float atkRage = .5f;

    public GameObject atackPoint;
    public LayerMask enermyLayer;
    public int _combo=1;
    public bool _atk=false;
    public Animator _anim;
    private void Update()
    {
        if (Input.GetButtonDown("MeleeAtack"))
        {
            Combo();
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
        if (_combo < 6)
        {
            _combo++;
        }
        Melee(20);
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
        }
    }
}
