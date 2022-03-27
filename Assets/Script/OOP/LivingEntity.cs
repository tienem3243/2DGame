using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    [Header("Entity name")]
    [Tooltip("Entity name")]
    [SerializeField]
    private string _characterName;

    [Header("Entity Health Point")]
    [SerializeField]
    protected float _maxHitPoint;
    [SerializeField]
    protected float _hitPoint;
    [SerializeField]
    protected HeathBarController _heathBar;

    protected Animation _deadEffect;
    public AnimationClip deadEffect;

    /// <summary> make healbar display </summary> 
    private void Start()
    {
        _deadEffect.clip = deadEffect;
        _heathBar.SetHealthBar(_hitPoint, _maxHitPoint);
    }
    public abstract void takeDamage(float damage);

    public virtual void ProtectStats()
    {
        _hitPoint = Mathf.Clamp(_hitPoint, 0, _maxHitPoint);
    }
    public void EntityDestroy()
    {
        Destroy(gameObject);
    }

}
