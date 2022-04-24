using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeTrigger : MonoBehaviour
{
    [SerializeField] string nameGame;
    [SerializeField] bool isPlaying;
    private void Start()
    {
        isPlaying = false;
    }
    private void Update()
    {
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&Input.GetKey(KeyCode.X))
        {
            isPlaying = !isPlaying;
           
            SceneManager.LoadScene(nameGame);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlaying = !isPlaying;
        }
    }

}
