using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_MT_NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public AudioClip noteSong;
    public KeyCode keyToPress;

    public GameObject hitEffect;
    public int scorePoint;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                AudioSource.PlayClipAtPoint(noteSong, transform.position, 100);

                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                MG_MT_GameManager.instance.NoteHit(scorePoint);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            MG_MT_GameManager.instance.NoteMiss();
        }
    }
}
