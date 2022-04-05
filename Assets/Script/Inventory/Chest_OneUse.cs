using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_OneUse : MonoBehaviour
{
    [SerializeField]
    private bool _isEnable;
    [SerializeField]
    private bool _isOpen;

    public Animator anim;
    public Item[] _prefab;


    private void Start()
    {
        _isEnable = false;
        _isOpen = false;

    }

    private void Update()
    {
        if (_isEnable && !_isOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // change value before display
                _isOpen = true;
                anim.SetBool("IsOpen", true);
                dropRandomItem();
            }
        }
    }

    public void dropRandomItem()
    {
        int pos = Random.Range(0, _prefab.Length);
        Debug.Log("Drop item at pos " + pos + " has lenght : " + _prefab.Length);

        Instantiate(_prefab[pos], gameObject.transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isEnable = true;
        }
    }

}
