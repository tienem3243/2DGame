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

                Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y, -3.0f)
                , hitEffect.transform.rotation);
                MG_MT_GameManager.instance.NoteHit(scorePoint);

                //Destroy
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
        if (other.tag == "Zone")
        {
            Destroy(gameObject);
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
