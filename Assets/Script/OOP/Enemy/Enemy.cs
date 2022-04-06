using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    [SerializeField]
    protected HeathBarController _heathBar;
    private bool isVisualHP;//variable that decide when hp is visible

    public DropRandomItem dropRandomItem;

    private void Start()
    {
        Instantiate(_heathBar, transform);
        _heathBar = GetComponentInChildren<HeathBarController>();
        _heathBar.setCanvasGroupAlpha(0);//just like other alpha that can make it invisible
        _heathBar.SetHealthBar(_hitPoint, _maxHitPoint);
    }
    public override void takeDamage(float damage)
    {
        if (base._hitPoint < _maxHitPoint && !isVisualHP)
        {
            _heathBar.setCanvasGroupAlpha(1);
            isVisualHP = true;

        }
        Mathf.Clamp(base._hitPoint, 0, base._maxHitPoint);
        base._hitPoint -= damage;
        _heathBar.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint <= 0)
        {
            // Do something for player die
            // DropRandomItem._instance.dropRandomItem();
            dropRandomItem.dropRandomItem();
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