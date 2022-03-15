using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{
    private void Start()
    {
        base.heathBar.SetHealthBar(base.hitPoint, base.maxHitPoint);
    }

    public override void takeDamage(float damage)
    {
        base.hitPoint -= damage;
        base.heathBar.SetHealthBar(base.hitPoint, base.maxHitPoint);

        if (base.hitPoint <= 0)
        {
            // Do something for player die
            EntityDestroy();
        }
    }
}
