using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity 
{
    [SerializeField] private float _atk;
    [SerializeField] private float _def;
    public GUIPlayer gui;
    public override void takeDamage(float damage)
    {
        base._hitPoint -= damage;
        this.gui.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint <= 0)
        {
            // Do something for player die
            EntityDestroy();
        }
    }
    public float GetAtk()
    {
        return _atk;
    }

    public override void EntityDestroy()
    {
        throw new System.NotImplementedException();
    }
}
