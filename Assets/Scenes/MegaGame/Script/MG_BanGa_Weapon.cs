using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_BanGa_Weapon : MonoBehaviour
{
    [Header("Asset")]
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private KeyCode[] _fireButton = { KeyCode.Mouse0, KeyCode.Space };

    [Space(10)]
    [Header("Infor")]
    [SerializeField]
    private float _fireDelay = 0.0f;
    [SerializeField]
    private float _timeDelay = 0.5f;

    private void Update()
    {
        if ((Input.GetKey(_fireButton[0]) || (Input.GetKey(_fireButton[1])))
            && Time.time > _fireDelay)
        {
            _fireDelay = Time.time + _timeDelay;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}
