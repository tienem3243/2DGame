using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    [SerializeField]private Vector2 NextPortalPos;

   public SceneTransfer sc;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (collision.CompareTag("Player"))
            {
                StartCoroutine(TeleportPos(collision));
            }
          
            
        }
       
    }
    IEnumerator TeleportPos(Collider2D collision)
    {  
        yield return new WaitForSeconds(0.5f);
        sc.LoadScene();
        collision.GetComponent<CharacterController2D>().MoveToPosition( NextPortalPos);
    }
}
