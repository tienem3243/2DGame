using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField]
    private bool _isEnable;
    [SerializeField]
    private bool _isOpen;

    public Animator anim;
    public GameObject invertoryChestMenu;

    private void Start()
    {
        _isEnable = false;
        _isOpen = false;

        invertoryChestMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isEnable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // change value before display
                _isOpen = !_isOpen;
                chestLogic();
            }
        }
    }

    void chestLogic()
    {
        if (_isOpen)
        {
            Debug.Log("Player opening the chest");
            // Do something here for display chest
        }
        else
        {
            Debug.Log("Chest closed");
            // Close
        }
        invertoryChestMenu.gameObject.SetActive(_isOpen);

        //test
        
        // test
        anim.SetBool("IsOpen", _isOpen);
    }

    void chestLogic(bool flag)
    {
        _isOpen = flag;
        chestLogic();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player eneter chest's zone");

            _isEnable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player leave chest's zone");

            _isEnable = false;
            chestLogic(false);
        }
    }
}
