using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    [SerializeField]
    protected HeathBarController _heathBar;

    private void Start()
    {
        _heathBar.SetHealthBar(_hitPoint, _maxHitPoint);
    }

    public override void takeDamage(float damage)
    {
        base._hitPoint -= damage;
        _heathBar.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint <= 0)
        {
            // Do something for player die
            EntityDestroy();
        }
    }

    public override void EntityDestroy()
    {
        gameObject.SetActive(false);

        if (_deathSound != null)
        {
            AudioSource.PlayClipAtPoint(_deathSound, transform.position, 100);
        }

        // this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);

        if (_deathEffect != null)
        {
            Instantiate(_deathEffect, transform.position, _deathEffect.transform.rotation);
        }
        Destroy(gameObject, 3);
    }

}