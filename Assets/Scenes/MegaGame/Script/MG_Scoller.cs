using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Scoller : MonoBehaviour
{
    [Header("Controll Rhythm")]
    [SerializeField]
    [Tooltip("Nhip do hay la toc do di chuyen")]
    private float _tempo;
    [SerializeField]
    private bool _isStart;

    public GameObject _prefab;

    float timeWait = 0.0f;

    public void setIsStart(bool flag)
    {
        _isStart = flag;
    }

    private void Start()
    {
        _isStart = false;
    }

    private void Update()
    {
        if (_isStart)
        {
            transform.position -= new Vector3(_tempo * Time.deltaTime, 0f, 0f);


            if (Time.time > timeWait)
            {
                //spawn obj prefab
                Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
                timeWait = Time.time + 5.0f;
            }

        }
    }
}