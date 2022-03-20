using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{
    public override void takeDamage(float damage)
    {
        base._hitPoint -= damage;
        base._heathBar.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint <= 0)
        {
            // Do something for player die
            EntityDestroy();
        }
    }
}
