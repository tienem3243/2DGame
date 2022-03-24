using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_BanGa_Bullet : MonoBehaviour
{
    [Header("Bullet infor")]
    [SerializeField]
    private float _speedBullet;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D.velocity = transform.up * _speedBullet;
        // _rb2D.velocity = transform.right * _speedBullet;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Zone")
        // {
        //     Destroy(gameObject);
        // }
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(_damage);
            }
        }
        if (!other.CompareTag("Player") && !other.CompareTag("Bullet"))// TODO need better logic
            Destroy(gameObject);
    }
}
