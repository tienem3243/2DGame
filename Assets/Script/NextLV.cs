using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLV : MonoBehaviour
{
    public SceneTransfer trans;
    [SerializeField] private Vector2 NextPortalPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(TeleportPos(collision));
    }
    IEnumerator TeleportPos(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
       trans.LoadScene();
        collision.GetComponent<CharacterController2D>().MoveToPosition(NextPortalPos);
    }
    public void NextLvButton()
    {
        Collider2D col = FindObjectOfType<CharacterController2D>().GetComponent<Collider2D>();
        StartCoroutine(TeleportPos(col));
    }
}
