using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    [Header("Entity name")]
    [Tooltip("Entity name")]
    public string name;

    [Header("Entity Health Point")]
    protected float maxHitPoint;
    protected float hitPoint;
    public HeathBarController heathBar;


    public abstract void takeDamage(float damage);

    public virtual void ProtectStats()
    {
        hitPoint = Mathf.Clamp(hitPoint, 0, maxHitPoint);
    }
    public void EntityDestroy()
    {
        Destroy(gameObject);
    }

}
