using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : LivingEntity
{
    [SerializeField] private float _atk;
    [SerializeField] private float _def;
    [SerializeField] public PlayerMovement Movement;
    public GUIPlayer gui;

    [Header("Inventory")]
    public bool _isOpen;
    public GameObject _inventoryPlayerMenu;

    public void setAtk(float atk)
    {
        this._atk = atk;
    }
    public float getAtk()
    {
        return this._atk;
    }
    public void setDef(float def)
    {
        this._def = def;
    }
    public float getDef()
    {
        return this._def;
    }

    private void Start()
    {
        _isOpen = false;
        _inventoryPlayerMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _isOpen = !_isOpen;
            _inventoryPlayerMenu.gameObject.SetActive(_isOpen);
        }
    }

    public void takeDamage(float damage,Vector3 sourcePos)
    {
        Movement.TakeDame(sourcePos);
        Debug.Log(transform.name);
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
        Debug.Log("gameOVer");
        gameObject.GetComponentInChildren<UnitData>().Load();
    }

    public override void takeDamage(float damage)
    {
        Movement.TakeDame();
        base._hitPoint -= damage;
        this.gui.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint <= 0)
        {
            // Do something for player die
            EntityDestroy();
        }
    }
}
